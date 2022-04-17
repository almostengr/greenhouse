using System;
using Almostengr.GardenMgr.Api.Enums;
using Almostengr.GardenMgr.Api.Models;

namespace Almostengr.GardenMgr.Api.DataTransferObjects
{
    public class PlantingDto : DtoBase
    {
        public PlantingDto(Planting planting)
        {
            PlantingId = planting.PlantingId;
            PlantTypeId = (int)planting.PlantType.PlantTypeId;
            PlantingStatusId = planting.PlantingStatus;
            ZoneId = planting.ZoneId;
            DatePlanted = planting.DatePlanted;
            DateHarvested = planting.DateHarvested;
            IsFrostTolerant = planting.IsFrostTolerant;
            MaturityDate = planting.MaturityDate;
            MaturityDays = planting.MaturityDays;
            Notes = planting.Notes;
            Created = planting.Created;
            Modified = planting.Modified;
        }

        public int PlantingId { get; set; }
        public int PlantTypeId { get; set; }
        public PlantingStatus PlantingStatusId { get; set; }
        public int ZoneId { get; set; }
        public DateTime DatePlanted { get; set; }
        public DateTime DateHarvested { get; set; }
        public bool IsFrostTolerant { get; set; }
        public DateTime MaturityDate { get; set; }
        public int MaturityDays { get; set; }
        public string Notes { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}