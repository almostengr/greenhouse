using System.Device.Gpio;

namespace Almostengr.GardenMgr.Api.GpioConnection
{
    public abstract class BaseGpioConnection : IBaseGpioConnection
    {
        private readonly GpioController _gpio;
        
        protected BaseGpioConnection(GpioController gpio)
        {
            _gpio = gpio;
        }

        public void OpenPin(GpioController gpio, PinMode pinMode, int pin)
        {

            gpio.OpenPin(pin, pinMode);
        }

        public void ClosePin(GpioController gpio, int pin)
        {

            gpio.ClosePin(pin);
        }
    }
}