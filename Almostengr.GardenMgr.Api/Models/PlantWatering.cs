using System;

namespace Almostengr.GardenMgr.Api.Models
{
    public class PlantWatering : ModelBase
    {
        public int PlantWateringId { get; set; }
        public int ZoneId { get; set; }
        public double Amount { get; }
        public DateTime Created { get; set; }
    }
}