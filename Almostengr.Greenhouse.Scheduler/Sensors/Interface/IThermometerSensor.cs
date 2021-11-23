using System.Threading.Tasks;

namespace Almostengr.Greenhouse.Scheduler.Sensors.Interface
{
    public interface IThermometerSensor
    {
        Task<double> GetTemperatureCelsiusAsync();
    }
}