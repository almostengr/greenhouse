using System.Threading.Tasks;
using Almostengr.GardenMgr.WeatherStation.DataTransferObjects;

namespace Almostengr.GardenMgr.WeatherStation.Sensors.Interface
{
    public interface ISensor
    {
        Task<ObservationDto> GetSensorDataAsync();
    }
}