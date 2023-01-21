using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Almostengr.Common.Twitter.Services
{
    public class MockTwitterService : ITwitterService
    {
        private readonly ILogger<MockTwitterService> _logger;

        public MockTwitterService(ILogger<MockTwitterService> logger)
        {
            _logger = logger;
        }

        public async Task<string> GetAuthenticatedUserAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            return "MockUser";
        }

        public async Task<bool> PostAlarmTweetAsync(List<string> users, string tweet, bool testing = false)
        {
            foreach(string user in users)
            {
                tweet = user + " " + tweet;
            }

            return await PostTweetAsync(tweet);
        }

        public async Task<bool> PostTweetAsync(string tweet, bool testing = false)
        {
            await Task.Delay(TimeSpan.FromSeconds(1));

            _logger.LogInformation("Tweeting: " + tweet);
            
            return true;
        }
        
    }
}