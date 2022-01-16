using System.Threading.Tasks;

namespace Almostengr.GardenMgr.Web.ServiceClients
{
    public interface IBaseServiceClient
    {
        Task<T> HttpGetAsync<T>(string route);
    }
}