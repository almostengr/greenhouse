using System.Diagnostics;
using System.Threading.Tasks;
using Almostengr.Greenhouse.Api.DataTransferObjects;
using Almostengr.Greenhouse.Api.Sensors.Interfaces;

namespace Almostengr.Greenhouse.Api.Sensors
{
    public class Ds18b20Sensor : ITemperatureSensor
    {
        public Task<TemperatureDto> GetTemperatureAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<double> GetTemperatureCelsiusAsync()
        {
            Process process = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = "/usr/bin/digitemp_DS9097",
                    Arguments = $"-a -q -c /etc/digitemp.conf -o \"%.2F,%.2C\"",
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };

            process.Start();
            process.WaitForExit();

            string output = process.StandardOutput.ReadToEnd();

            // return output;
            return 0.0; // todo update to return the actual temperature
        }
    }
}