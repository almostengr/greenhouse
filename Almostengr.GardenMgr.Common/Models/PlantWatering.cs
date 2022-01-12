using System;

namespace Almostengr.GardenMgr.Common.Models
{
    public class PlantWatering : BaseDto
    {
        // public Irrigation(IrrigationDto irrigationDto)
        // {
        //     Id = irrigationDto.Id;
        //     Created = irrigationDto.Created;
        //     Amount = irrigationDto.Amount;
        //     ZoneId = irrigationDto.ZoneId;
        // }

        public int Id { get; set; }
        public DateTime Created { get; set; }
        public double Amount { get; }
        public int ZoneId { get; set; }

    }
}