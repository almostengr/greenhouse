using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Tweetinvi;

namespace Almostengr.Common.Twitter.Services
{
    public class TwitterService : ITwitterService
    {
        private readonly ITwitterClient _twitterClient;
        private readonly ILogger<TwitterService> _logger;

        public TwitterService(ITwitterClient twitterClient, ILogger<TwitterService> logger)
        {
            _twitterClient = twitterClient;
            _logger = logger;
        }

        public async Task<string> GetAuthenticatedUserAsync()
        {
            var response = await _twitterClient.Users.GetAuthenticatedUserAsync();
            _logger.LogInformation($"Authenticated to Twitter as {response.Name}");
            return response.Name;
        }

        public async Task<bool> PostAlarmTweetAsync(List<string> users, string tweet, bool testing = false)
        {
            foreach (var user in users)
            {
                tweet = user + " " + tweet;
            }

            return await PostTweetAsync(tweet, testing);
        }

        public async Task<bool> PostTweetAsync(string tweet, bool testing = false)
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

            if (testing == false)
            {
                await Task.Delay(TimeSpan.FromSeconds(2));
                _logger.LogInformation("Sent testing tweet");
                return true;
            }

            var response = await _twitterClient.Tweets.PublishTweetAsync(tweet);
            _logger.LogInformation("Sent tweet at: " + response.CreatedAt.ToString());
            return response.CreatedBy.Name.Length > 0 ? true : false;
        }
    }
}