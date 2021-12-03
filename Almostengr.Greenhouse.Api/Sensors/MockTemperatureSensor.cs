using System;
using System.Threading.Tasks;
using Almostengr.Greenhouse.Api.DataTransferObjects;
using Almostengr.Greenhouse.Api.Sensors.Interfaces;

namespace Almostengr.Greenhouse.Api.Sensors.Mock
{
    public class MockTemperatureSensor : ITemperatureSensor
    {
        public async Task<TemperatureDto> GetTemperatureAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            
            Random random = new Random();
            return new TemperatureDto
            {
                TemperatureF = random.Next(10, 100),
                Humidity = random.Next(0, 100),
                HumidityUnit = "%",
            };
        }
    }
}