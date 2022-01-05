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
            TemperatureC = observationDto.TemperatureC;
            Humidity = observationDto.Humidity;
            Pressure = observationDto.Pressure;
            Created = observationDto.Created;
        }

        
        [Key]
        public int ObservationId { get; set; }

        [Required]
        public double TemperatureC { get; set; }

        public double? Humidity { get; set; }
        public double? Pressure { get; set; }

        [Required]
        public DateTime Created { get; set; }

        public static Expression<Func<Observation, ObservationDto>> ToDto()
        {
            return o => new ObservationDto
            {
                ObservationId = o.ObservationId,
                TemperatureC = Math.Round(o.TemperatureC, Constants.MAX_DECIMAL_PLACES),
                TemperatureF = Math.Round(((o.TemperatureC * 1.8) + 32), Constants.MAX_DECIMAL_PLACES),
                Humidity = o.Humidity,
                Pressure = o.Pressure,
                Created = o.Created
            };
        }
        
        public static ObservationDto AsDto(this Observation observation)
        {
            return new ObservationDto{
                ObservationId = observation.ObservationId,
                TemperatureC = Math.Round(observation.TemperatureC, Constants.MAX_DECIMAL_PLACES),
                TemperatureF = Math.Round(((observation.TemperatureC * 1.8) + 32), Constants.MAX_DECIMAL_PLACES),
                Humidity = observation.Humidity,
                Pressure = observation.Pressure,
                Created = observation.Created
            };
        }

    }
}
