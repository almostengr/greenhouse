using System;
using System.Threading.Tasks;
using Almostengr.GardenMgr.Api.DataTransferObjects;

namespace Almostengr.GardenMgr.Api.Sensors
{
    public class MockTemperatureSensor : ITemperatureSensor
    {
        public async Task<ObservationDto> GetTemperatureDataAsync()
        {
            Random random = new();
            await Task.Delay(TimeSpan.FromSeconds(0.5));

            return new ObservationDto
            {
                TemperatureC = random.Next(-10, 40),
                HumidityPct = random.Next(0, 100),
                PressureMb = random.Next(500, 1500),
            };
        }
    }
}