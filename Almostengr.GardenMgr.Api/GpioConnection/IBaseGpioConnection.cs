using System.Device.Gpio;

namespace Almostengr.GardenMgr.Api.GpioConnection
{
    public interface IBaseGpioConnection
    {
        void OpenPin(GpioController gpio, PinMode pinMode, int pin);
        void ClosePin(GpioController gpio, int pin);
    }
}