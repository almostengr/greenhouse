using System.Device.Gpio;
using Almostengr.GardenMgr.Common.Enums;

namespace Almostengr.GardenMgr.Common.Relays
{
    public interface IBaseRelay
    {
        void TurnOn(GpioRelayPin pinNumber);
        void TurnOff(GpioRelayPin pinNumber);
        bool IsOn();
        
        void OpenPins(GpioController gpio, PinMode pinMode, int[] pins);
        void OpenPin(GpioController gpio, PinMode pinMode, int pin);
        void ClosePins(GpioController gpio, int[] pins);
        void ClosePin(GpioController gpio, int pin);
    }
}