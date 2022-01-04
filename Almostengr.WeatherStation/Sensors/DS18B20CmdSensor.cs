using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Almostengr.WeatherStation.DataTransferObjects;
using Almostengr.WeatherStation.Sensors.Interface;

namespace Almostengr.WeatherStation.Sensors
{
    public class DS18B20CmdSensor : ISensor
    {
        public Task<ObservationDto> GetSensorDataAsync()
        {
            Process process = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = "/usr/bin/digitemp_DS9097",
                    Arguments = $"-a -q -c /etc/digitemp.conf -o \"%.2C\"",
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };

            process.Start();
            process.WaitForExit();

            var observationDto = new ObservationDto
            {
                TemperatureC = Double.Parse(process.StandardOutput.ReadToEnd()),
                Humidity = null,
                Pressure = null,
            };

            return Task.FromResult(observationDto);
        }
    }
}