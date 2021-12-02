using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.Greenhouse.Api.Common;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Tweetinvi;

namespace Almostengr.Greenhouse.Api
{
    public abstract class BaseWorker : BackgroundService
    {
        private readonly ILogger<BaseWorker> _logger;
        private readonly ITwitterClient _twitterClient;
        private readonly AppSettings _appSettings;

        public BaseWorker(ILogger<BaseWorker> logger, ITwitterClient twitterClient, AppSettings appSettings)
        {
            _logger = logger;
            _twitterClient = twitterClient;
            _appSettings = appSettings;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }

        public async Task<bool> PostTweetAsync(string tweet)
        {
            if (string.IsNullOrEmpty(tweet))
            {
                _logger.LogWarning("Nothing to tweet");
                return false;
            }

            // trim the tweet between words if it is too long
            while (tweet.Length > Constants.TWEET_MAX_LENGTH)
            {
                tweet = tweet.Substring(0, tweet.LastIndexOf(" "));
            }

            _logger.LogInformation("Tweeting: " + tweet);

#if RELEASE
            var response = await _twitterClient.Tweets.PublishTweetAsync(tweet);
            _logger.LogInformation("Sent tweet at: " + response.CreatedAt.ToString());
            return response.CreatedBy.Name.Length > 0 ? true : false;
#else
            await Task.Delay(TimeSpan.FromSeconds(1));
            _logger.LogInformation("Sent testing tweet");
            return true;
#endif
        }

        public async Task<bool> PostAlarmTweetAsync(string tweet)
        {
            return await PostTweetAsync(string.Concat(_appSettings.Twitter.AlarmUsers, " ", tweet));
        }

        public async Task<T> HttpGetAsync<T>(HttpClient httpClient, string route) where T : class
        {
            HttpResponseMessage response = await httpClient.GetAsync(route);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
