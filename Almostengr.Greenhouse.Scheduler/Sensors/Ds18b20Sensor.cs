using System.Diagnostics;
using System.Threading.Tasks;
using Almostengr.Greenhouse.Scheduler.Sensors.Interface;

namespace Almostengr.Greenhouse.Scheduler.Sensors
{
    public class Ds18b20Sensor : IThermometerSensor
    {
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