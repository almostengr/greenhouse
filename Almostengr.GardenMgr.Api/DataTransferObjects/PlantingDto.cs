using System;
using Almostengr.GardenMgr.Api.Models;

namespace Almostengr.GardenMgr.Api.DataTransferObjects
{
    public class PlantingDto : DtoBase
    {
        public PlantingDto(Planting planting)
        {
            PlantingId = planting.PlantingId;
            PlantTypeId = (int)planting.PlantType.PlantTypeId;
            PlantingStatusId = (int)planting.PlantingStatus;
            ZoneId = planting.ZoneId;
            DatePlanted = planting.DatePlanted;
            DateHarvested = planting.DateHarvested;
            IsFrostTolerant = planting.IsFrostTolerant;
            MaturityDays = planting.MaturityDays;
            Notes = planting.Notes;
            Created = planting.Created;
            Modified = planting.Modified;
        }

        public int PlantingId { get; internal set; }
        public int PlantTypeId { get; internal set; }
        public int PlantingStatusId { get; internal set; }
        public int ZoneId { get; internal set; }
        public DateTime DatePlanted { get; internal set; }
        public DateTime DateHarvested { get; internal set; }
        public bool IsFrostTolerant { get; internal set; }
        public int MaturityDays { get; internal set; }
        public string Notes { get; internal set; }
        public DateTime Created { get; internal set; }
        public DateTime Modified { get; internal set; }
    }
}