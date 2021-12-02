using System.Threading.Tasks;
using Almostengr.Greenhouse.Api.DataTransferObjects;

namespace Almostengr.Greenhouse.Api.Sensors.Interfaces
{
    public interface ITemperatureSensor
    {
        Task<TemperatureDto> GetTemperatureAsync();
    }
}