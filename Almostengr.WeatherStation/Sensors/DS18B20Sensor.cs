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

            // reference https://github.com/dotnet/iot/tree/main/src/devices/OneWire

            // Quick and simple way to find a thermometer and print the temperature
            foreach (var dev in OneWireThermometerDevice.EnumerateDevices())
            {
                // Console.WriteLine($"Temperature reported by '{dev.DeviceId}': " +
                //                     (await dev.ReadTemperatureAsync()).DegreesCelsius.ToString("F2") + "\u00B0C");
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