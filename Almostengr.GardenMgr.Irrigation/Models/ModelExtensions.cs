using Almostengr.GardenMgr.Irrigation.Api.DataTransfer;

namespace Almostengr.GardenMgr.Irrigation.Api.Models
{
    public static class ModelExtensions
    {
        public static IrrigationDto ToIrrigationDto(this Irrigation irrigation)
        {
            return new IrrigationDto
            {
                Id = irrigation.Id,
                Created = irrigation.Created,
                Amount = irrigation.Amount,
                ZoneId = irrigation.ZoneId
            };
        }
    }
}