using System;

namespace Almostengr.WeatherStation.DataTransferObjects
{
    public class ObservationDto : DtoBase
    {
        public int ObservationId { get; set; }
        public double TemperatureC { get; set; }
        public double? TemperatureF { get; set; }
        public double? Humidity { get; set; }
        public double? Pressure { get; set; }
        public DateTime Created { get; set; }
    }
}