using System.Threading.Tasks;
using Almostengr.GardenMgr.Api.DataTransferObjects;

namespace Almostengr.GardenMgr.Api.Sensors
{
    public interface ITemperatureSensor
    {
        Task<ObservationDto> GetTemperatureDataAsync();
    }
}