using Almostengr.GardenMgr.Api.GpioConnection;

namespace Almostengr.GardenMgr.Api.Relays
{
    public interface IBaseRelay : IBaseGpioConnection
    {
        void TurnOn(int pinNumber);
        void TurnOff(int pinNumber);
        void OpenPin(int pin);
    }
}