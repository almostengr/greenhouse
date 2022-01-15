using System.Device.Gpio;

namespace Almostengr.GardenMgr.Api.Relays
{
    public abstract class BaseRelay : IBaseRelay
    {
        private readonly GpioController _gpio;
        
        public BaseRelay(GpioController gpio)
        {
            _gpio = gpio;
        }

        public void TurnOff(int pinNumber)
        {
            _gpio.Write(pinNumber, PinValue.Low);
        }

        public void TurnOn(int pinNumber)
        {
            _gpio.Write(pinNumber, PinValue.High);
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