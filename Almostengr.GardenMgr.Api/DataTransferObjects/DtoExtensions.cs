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
    }   
}