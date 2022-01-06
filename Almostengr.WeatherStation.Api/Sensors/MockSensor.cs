using System;
using System.Threading.Tasks;
using Almostengr.WeatherStation.Api.DataTransferObjects;
using Almostengr.WeatherStation.Api.Sensors.Interface;

namespace Almostengr.WeatherStation.Api.Sensors
{
    public class MockSensor : ISensor
    {
        public async Task<ObservationDto> GetSensorDataAsync()
        {
            Random random = new();
            await Task.Delay(TimeSpan.FromSeconds(1));

            return new ObservationDto
            {
                TemperatureC = random.Next(-10, 40),
                HumidityPct = random.Next(0, 100),
                PressureMb = random.Next(0, 1000),
            };
        }
    }
}