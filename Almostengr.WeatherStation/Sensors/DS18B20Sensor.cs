using System;
using System.Threading.Tasks;
using Almostengr.WeatherStation.DataTransferObjects;
using Almostengr.WeatherStation.Sensors.Interface;
using Iot.Device.OneWire;

namespace Almostengr.WeatherStation.Sensors
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
                Humidity = null,
                Pressure = null,
            };
        }
    }
}