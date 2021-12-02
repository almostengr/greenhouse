using System.Threading.Tasks;

namespace Almostengr.Greenhouse.Api.Sensors.Interfaces
{
    public interface IWaterSensor
    {
        Task<bool> IsSoilWet();
    }
}