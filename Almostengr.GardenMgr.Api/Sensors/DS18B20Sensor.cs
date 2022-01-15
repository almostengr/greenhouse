using System;
using System.Threading.Tasks;
using Almostengr.GardenMgr.Api.DataTransferObjects;
using Almostengr.GardenMgr.Api.Sensors.Interface;
using Iot.Device.OneWire;

namespace Almostengr.GardenMgr.Api.Sensors
{
    public class DS18B20Sensor : ISensor
    {
        public async Task<ObservationDto> GetSensorDataAsync()
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