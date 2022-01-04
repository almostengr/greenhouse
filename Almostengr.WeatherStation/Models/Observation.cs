using System;
using Almostengr.WeatherStation.DataTransferObjects;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace Almostengr.WeatherStation.Models
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
            TemperatureC = observationDto.TemperatureC == null ? observationDto.TemperatureF : observationDto.TemperatureC;
            Humidity = observationDto.Humidity;
            Pressure = observationDto.Pressure;
            Created = observationDto.Created;
        }

        
        [Key]
        public int ObservationId { get; set; }

        [Required]
        public double? TemperatureC { get; set; }

        public double? Humidity { get; set; }
        public double? Pressure { get; set; }

        [Required]
        public DateTime Created { get; set; }

        public static Expression<Func<Observation, ObservationDto>> ToDto()
        {
            return o => new ObservationDto
            {
                ObservationId = o.ObservationId,
                TemperatureC = o.TemperatureC,
                Humidity = o.Humidity,
                Pressure = o.Pressure,
                Created = o.Created
            };
        }

    }
}