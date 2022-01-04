using System;
using System.Threading.Tasks;
using Almostengr.WeatherStation.DataTransferObjects;
using Almostengr.WeatherStation.Sensors.Interface;

namespace Almostengr.WeatherStation.Sensors
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
                Humidity = random.Next(0, 100),
                Pressure = random.Next(0, 1000),
            };
        }
    }
}