using System.Threading.Tasks;
using Almostengr.WeatherStation.DataTransferObjects;

namespace Almostengr.WeatherStation.Sensors.Interface
{
    public interface ISensor
    {
        Task<ObservationDto> GetSensorDataAsync();
    }
}