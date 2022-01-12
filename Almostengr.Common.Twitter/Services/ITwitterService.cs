using System.Threading.Tasks;

namespace Almostengr.Common.Twitter.Services
{
    public interface ITwitterService
    {
        Task<string> GetAuthenticatedUserAsync();
        Task<bool> PostTweetAsync(string tweet, bool testing = false);
    }
}