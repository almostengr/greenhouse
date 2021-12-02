using System.ComponentModel.DataAnnotations;
using Almostengr.Greenhouse.Api.Common;
using Almostengr.Greenhouse.Api.DataTransferObject;

namespace Almostengr.Greenhouse.Api.Models
{
    public class Temperature : BaseModel
    {
        public Temperature() { }

        public Temperature(NwsObservationLatestDto dto)
        {
            Created = dto.Properties[0].Timestamp;
            Degrees = dto.Properties[0].Temperature.Value;
            TemperatureUnit = dto.Properties[0].Temperature.UnitCode;
            Humidity = dto.Properties[0].RelativeHumidity.Value;
            HumidityUnit = dto.Properties[0].RelativeHumidity.UnitCode;
        }

        [Required]
        public TemperatureSource SourceId { get; set; }

        public string Location { get; set; }

        [Required]
        public double? Degrees { get; set; }

        [Required]
        public string TemperatureUnit { get; set; }
        
        public double TemperatureF { get; set; }

        public double TemperatureC { get; set; }

        public double? Humidity { get; set; }

        public string HumidityUnit { get; set; }
    }
}