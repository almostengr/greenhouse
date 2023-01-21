using System;
using Almostengr.GardenMgr.Api.Models;
using Almostengr.GardenMgr.Api.DataTransferObjects;

namespace Almostengr.GardenMgr.Api.Models
{
    public static class ModelExtensions
    {
        public static ObservationDto AsDto(this Observation observation)
        {
            return new ObservationDto{
                ObservationId = observation.ObservationId,
                TemperatureC = Math.Round(observation.TemperatureC, Constants.MAX_DECIMAL_PLACES),
                TemperatureF = Math.Round(((observation.TemperatureC * 1.8) + 32), Constants.MAX_DECIMAL_PLACES),
                HumidityPct = observation.HumidityPct,
                PressureMb = observation.PressureMb,
                Created = observation.Created
            };
        }
    }
}