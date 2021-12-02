using System;

namespace Almostengr.Greenhouse.Api.DataTransferObjects
{
    public class TemperatureDto
    {
        public int TemperatureId { get; set; }
        public DateTime Created { get; set; }
        public double TemperatureC { get; set; }
        public double TemperatureF { get; set; }
        public double? HumidityPct { get; set; }
        public string Location { get; set; }
        public string Source { get; set; }
    }
}