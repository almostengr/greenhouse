using System;
using System.Threading.Tasks;
using Almostengr.GardenMgr.Api.DataTransferObjects;
using Iot.Device.OneWire;

namespace Almostengr.GardenMgr.Api.Sensors
{
    public class DS18B20Sensor : ITemperatureSensor
    {
        public async Task<ObservationDto> GetTemperatureDataAsync()
        {
            string temp = string.Empty;

            foreach (var dev in OneWireThermometerDevice.EnumerateDevices())
            {
                temp = (await dev.ReadTemperatureAsync()).DegreesCelsius.ToString("F2");
            }

            return new ObservationDto
            {
                TemperatureC = Double.Parse(temp),
                HumidityPct = null,
                PressureMb = null,
            };
        }
    }
}