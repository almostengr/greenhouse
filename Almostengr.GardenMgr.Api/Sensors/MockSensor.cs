using System;
using System.Threading.Tasks;
using Almostengr.GardenMgr.Api.DataTransferObjects;
using Almostengr.GardenMgr.Api.Sensors.Interface;

namespace Almostengr.GardenMgr.Api.Sensors
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
                PressureMb = random.Next(500, 1500),
            };
        }
    }
}