using System;
using Almostengr.Greenhouse.Api.DataTransferObjects;

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

        public string SensorName { get; set; }

        public double? Degrees { get; set; }

        public string TemperatureUnit { get; set; }

        public double TemperatureF { get; set; }

        public double TemperatureC { get; set; }

        public double? Humidity { get; set; }

        public string HumidityUnit { get; set; }


        public TemperatureDto ToDto()
        {
            return new TemperatureDto
            {
                TemperatureId = Id,
                Created = Created,
                TemperatureF = TemperatureF,
                TemperatureC = TemperatureC,
                Humidity = Humidity,
                HumidityUnit = HumidityUnit,
                SensorName = SensorName,
            };
        }

        public void FromDto(TemperatureDto dto)
        {
            Id = dto.TemperatureId;
            Created = DateTime.Now;
            TemperatureF = dto.TemperatureF;
            TemperatureC = dto.TemperatureC;
            Humidity = dto.Humidity;
            HumidityUnit = dto.HumidityUnit;
            SensorName = dto.SensorName;
        }
    }
}