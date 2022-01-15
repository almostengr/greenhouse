using System.Device.Gpio;

namespace Almostengr.GardenMgr.Common.Relays
{
    public interface IBaseRelay
    {
        void TurnOn(int pinNumber);
        void TurnOff(int pinNumber);
        
        void OpenPin(GpioController gpio, PinMode pinMode, int pin);
        void ClosePin(GpioController gpio, int pin);
    }
}