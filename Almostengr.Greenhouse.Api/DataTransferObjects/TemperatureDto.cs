using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Almostengr.Greenhouse.Api.Models;

namespace Almostengr.Greenhouse.Api.DataTransferObjects
{
    public class TemperatureDto : BaseDto
    {
        public int TemperatureId { get; set; }
        
        public DateTime Created { get; set; }

        public double TemperatureF { get; set; }

        public double TemperatureC { get; set; }

        public double? Humidity { get; set; }

        public string HumidityUnit { get; set; }

        [Required]
        public string SensorName { get; set; }

        public static Expression<Func<Temperature, TemperatureDto>> ToTemperatureDto()
        {
            return t => new TemperatureDto
            {
                TemperatureId = t.Id,
                Created = t.Created,
                TemperatureF = t.TemperatureF,
                TemperatureC = t.TemperatureC,
                Humidity = t.Humidity,
                HumidityUnit = t.HumidityUnit,
                SensorName = t.SensorName
            };
        }

    }
}