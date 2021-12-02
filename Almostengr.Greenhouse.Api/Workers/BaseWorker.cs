using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.Greenhouse.Api.Common;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Tweetinvi;

namespace Almostengr.Greenhouse.Api.Workers
{
    public abstract class BaseWorker : BackgroundService
    {
        private readonly ILogger<BaseWorker> _logger;
        private readonly ITwitterClient _twitterClient;

        public BaseWorker(ILogger<BaseWorker> logger, ITwitterClient twitterClient)
        {
            _logger = logger;
            _twitterClient = twitterClient;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            var response = _twitterClient.Users.GetAuthenticatedUserAsync();
            _logger.LogInformation(string.Concat("Connected to twitter as ", response.Result.Name));
            return base.StartAsync(cancellationToken);
        }

        // todo - needs to have a conditional depending on credentials have been entered
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
            return await PostTweetAsync(string.Concat("@user", " ", tweet)); // todo - get user from config
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

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new System.NotImplementedException();
        }
    }
}