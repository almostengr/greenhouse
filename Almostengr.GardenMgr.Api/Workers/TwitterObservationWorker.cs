using System;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.Common.Twitter.Services;
using Almostengr.GardenMgr.Api.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Almostengr.GardenMgr.Api.Workers
{
    public class TwitterObservationWorker : BaseWorker
    {
        public readonly AppSettings _appSettings;
        private readonly IObservationService _observationService;
        private readonly ITwitterService _twitterService;
        private readonly ILogger<TwitterObservationWorker> _logger;

        public TwitterObservationWorker(AppSettings appSettings, IServiceScopeFactory factory, ILogger<TwitterObservationWorker> logger)
        {
            _appSettings = appSettings;
            _observationService = factory.CreateScope().ServiceProvider.GetRequiredService<IObservationService>();
            _twitterService = factory.CreateScope().ServiceProvider.GetRequiredService<ITwitterService>();
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken stoppingToken)
        {
            _twitterService.GetAuthenticatedUserAsync();
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

                    await _twitterService.PostTweetAsync(tweetText);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                }

                await Task.Delay(TimeSpan.FromMinutes(_appSettings.Weather.TweetInterval), stoppingToken);
            }
        }

    }
}