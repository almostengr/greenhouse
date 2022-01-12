namespace Almostengr.GardenMgr.Common.Services
{
    public class TwitterService : ITwitterService
    {
        private readonly ITwitterClient _twitterClient;

        public TwitterService(ITwitterClient twitterClient)
        {
            _twitterClient = twitterClient;
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

            if (testing == true)
            {
                var response = await _twitterClient.Tweets.PublishTweetAsync(tweet);
                _logger.LogInformation("Sent tweet at: " + response.CreatedAt.ToString());
                return response.CreatedBy.Name.Length > 0 ? true : false;
            }
            else
            {
                await Task.Delay(TimeSpan.FromSeconds(2));
                _logger.LogInformation("Sent testing tweet");
                return true;
            }
        }
    }
}