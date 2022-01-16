using System.Device.Gpio;
using Almostengr.GardenMgr.Api.GpioConnection;

namespace Almostengr.GardenMgr.Api.Relays
{
    public abstract class BaseRelay : BaseGpioConnection, IBaseRelay
    {
        private readonly GpioController _gpio;
        
        public BaseRelay(GpioController gpio) : base(gpio)
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

        public void OpenPin(int pin)
        {
            base.OpenPin(_gpio, PinMode.Output, pin);
        }

    }
}