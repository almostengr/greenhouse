using System;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.WeatherStation.Api.Services.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Tweetinvi;

namespace Almostengr.WeatherStation.Api.Workers
{
    public class TwitterWorker : BaseWorker
    {
        public readonly AppSettings _appSettings;
        private readonly IObservationService _observationService;
        private readonly ITwitterClient _twitterClient;
        private readonly ILogger<TwitterWorker> _logger;

        public TwitterWorker(AppSettings appSettings, IServiceScopeFactory factory, ILogger<TwitterWorker> logger)
        {
            _appSettings = appSettings;
            _observationService = factory.CreateScope().ServiceProvider.GetRequiredService<IObservationService>();
            _twitterClient = factory.CreateScope().ServiceProvider.GetRequiredService<ITwitterClient>();
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken stoppingToken)
        {
            var response = _twitterClient.Users.GetAuthenticatedUserAsync();
            _logger.LogInformation($"Authenticated to Twitter as {response.Result.Name}");
            return base.StartAsync(stoppingToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var observationDto = await _observationService.GetLatestObservationAsync();

                    var tweetText = $"Observation at {observationDto.Created} - ";
                    tweetText += $"{observationDto.TemperatureC} C, {observationDto.TemperatureF} F";

                    if (observationDto.HumidityPct != null)
                    {
                        tweetText += $"; {observationDto.HumidityPct}% humidity";
                    }

                    if (observationDto.PressureMb != null)
                    {
                        tweetText += $"; {observationDto.PressureMb} hPa";
                    }

                    await PostTweetAsync(tweetText);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                }

                await Task.Delay(TimeSpan.FromMinutes(_appSettings.Twitter.UpdateInterval), stoppingToken);
            }
        }

        private async Task<bool> PostTweetAsync(string tweet)
        {
            if (string.IsNullOrEmpty(tweet))
            {
                _logger.LogWarning("Nothing to tweet");
                return false;
            }

            tweet = tweet.Trim();
            tweet = tweet.Replace("  ", " ");

            // trim the tweet between words if it is too long
            while (tweet.Length > Constants.MAX_TWEET_LENGTH)
            {
                tweet = tweet.Substring(0, tweet.LastIndexOf(" "));
            }

            _logger.LogInformation("Tweeting: " + tweet);

#if RELEASE
            var response = await _twitterClient.Tweets.PublishTweetAsync(tweet);
            _logger.LogInformation("Sent tweet at: " + response.CreatedAt.ToString());
            return response.CreatedBy.Name.Length > 0 ? true : false;
#else
            await Task.Delay(TimeSpan.FromSeconds(2));
            _logger.LogInformation("Sent testing tweet");
            return true;
#endif
        }

    }
}