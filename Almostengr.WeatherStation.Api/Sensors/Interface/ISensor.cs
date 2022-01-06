using System.Threading.Tasks;
using Almostengr.WeatherStation.Api.DataTransferObjects;

namespace Almostengr.WeatherStation.Api.Sensors.Interface
{
    public interface ISensor
    {
        Task<ObservationDto> GetSensorDataAsync();
    }
}