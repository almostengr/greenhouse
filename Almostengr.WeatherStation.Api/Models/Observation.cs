using System;
using Almostengr.WeatherStation.Api.DataTransferObjects;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace Almostengr.WeatherStation.Api.Models
{
    public class Observation : ModelBase
    {
        public Observation()
        {}

        public Observation(ObservationDto observationDto)
        {
            if (observationDto == null)
            {
                throw new ArgumentNullException(nameof(observationDto));
            }

            ObservationId = observationDto.ObservationId;
            TemperatureC = observationDto.TemperatureC;
            HumidityPct = observationDto.HumidityPct;
            PressureMb = observationDto.PressureMb;
            Created = observationDto.Created;
        }

        [Key]
        public int ObservationId { get; set; }

        [Required]
        public double TemperatureC { get; set; }

        public double? HumidityPct { get; set; }
        public double? PressureMb { get; set; }

        [Required]
        public DateTime Created { get; set; }

    }
}
