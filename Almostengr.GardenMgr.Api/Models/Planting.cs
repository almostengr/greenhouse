using System;
using Almostengr.GardenMgr.Api.DataTransferObjects;
using Almostengr.GardenMgr.Api.Enums;

namespace Almostengr.GardenMgr.Api.Models
{
    public class Planting : ModelBase
    {

        public Planting() { }

        public Planting(PlantingDto plantingDto) { }

        public int PlantingId { get; set; }
        public PlantTypeDto PlantType { get; set; }
        public PlantingStatus PlantingStatus { get; set; }
        public int ZoneId { get; set; }
        public DateTime DatePlanted { get; set; }
        public DateTime DateHarvested { get; set; }
        public bool IsFrostTolerant { get; set; }
        public int MaturityDays { get; set; }
        public string Notes { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}