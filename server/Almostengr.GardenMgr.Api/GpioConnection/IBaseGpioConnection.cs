using System.Device.Gpio;

namespace Almostengr.GardenMgr.Api.GpioConnection
{
    public interface IBaseGpioConnection
    {
        void OpenPin(PinMode pinMode, int pin);
        void ClosePin(int pin);
    }
}