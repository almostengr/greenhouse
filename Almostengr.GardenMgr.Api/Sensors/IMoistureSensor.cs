using System.Threading.Tasks;
using Almostengr.GardenMgr.Irrigation.DataTransferObjects;

namespace Almostengr.Greenhouse.Api.Sensors.Interfaces
{
    public interface IMoistureSensor
    {
        Task<MoistureDto> IsSoilWet();
    }
}