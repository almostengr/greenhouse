using Almostengr.GardenMgr.Api.Enums;
using Almostengr.GardenMgr.Api.Models;

namespace Almostengr.GardenMgr.Api.DataTransferObjects
{
    public static class DtoExtensions
    {
        public static Observation ToObservation(this ObservationDto observationDto)
        {
            return new Observation{
                ObservationId = observationDto.ObservationId,
                TemperatureC = observationDto.TemperatureC,
                HumidityPct = observationDto.HumidityPct,
                PressureMb = observationDto.PressureMb,
                Created = observationDto.Created
            };
        }
        
        public static Planting ToPlanting(this PlantingDto plantingDto)
        {
            return new Planting
            {
                PlantingId = plantingDto.PlantingId,
                // PlantType = (PlantType)plantingDto.PlantTypeId, // todo
                PlantingStatus = (PlantingStatus)plantingDto.PlantingStatusId,
                ZoneId = plantingDto.ZoneId,
                DatePlanted = plantingDto.DatePlanted,
                DateHarvested = plantingDto.DateHarvested,
                IsFrostTolerant = plantingDto.IsFrostTolerant,
                MaturityDays = plantingDto.MaturityDays,
                Notes = plantingDto.Notes,
                Created = plantingDto.Created,
                Modified = plantingDto.Modified
            };
        }
        
    }   
}