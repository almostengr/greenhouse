using System.Threading.Tasks;

namespace Almostengr.Greenhouse.Scheduler.Sensors.Interface
{
    public interface IWaterSensor
    {
        Task<bool> IsSoilWet();
    }
}