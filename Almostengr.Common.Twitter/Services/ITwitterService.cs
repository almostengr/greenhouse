using System.Collections.Generic;
using System.Threading.Tasks;

namespace Almostengr.Common.Twitter.Services
{
    public interface ITwitterService
    {
        Task<string> GetAuthenticatedUserAsync();
        Task<bool> PostAlarmTweetAsync(List<string> users, string tweet, bool testing = false);
        Task<bool> PostTweetAsync(string tweet, bool testing = false);
    }
}