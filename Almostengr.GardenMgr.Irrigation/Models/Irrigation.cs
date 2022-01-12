using System;
using Almostengr.GardenMgr.Irrigation.Api.DataTransfer;

namespace Almostengr.GardenMgr.Irrigation.Api.Models
{
    public class Irrigation : BaseDto
    {
        public Irrigation(IrrigationDto irrigationDto)
        {
            Id = irrigationDto.Id;
            Created = irrigationDto.Created;
            Amount = irrigationDto.Amount;
            ZoneId = irrigationDto.ZoneId;
        }

        public int Id { get; set; }
        public DateTime Created { get; set; }
        public double Amount { get; }
        public int ZoneId { get; set; }

    }
}