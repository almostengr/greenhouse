using System;
using System.ComponentModel.DataAnnotations;

namespace Almostengr.WeatherStation.Api.DataTransferObjects
{
    public class ObservationDto : DtoBase
    {
        public int ObservationId { get; set; }

        [Required]
        public double TemperatureC { get; set; }
        
        public double? TemperatureF { get; set; }

        [Range(0,100)]
        public double? HumidityPct { get; set; }

        [Range(870, 1084)]
        public double? PressureMb { get; set; }
        
        public DateTime Created { get; set; }
    }
}