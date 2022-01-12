using System;
using System.Device.Gpio;
using Almostengr.GardenMgr.Common.Enums;

namespace Almostengr.GardenMgr.Common.Relays
{
    public abstract class BaseRelay : IBaseRelay
    {
        private readonly GpioController _gpio;
        public BaseRelay(GpioController gpio)
        {
            _gpio = gpio;
        }

        public bool IsOn()
        {
            throw new System.NotImplementedException();
        }

        public void TurnOff(GpioRelayPin pinNumber)
        {
            _gpio.Write((Int32)pinNumber, PinValue.Low);
        }

        public void TurnOn(GpioRelayPin pinNumber)
        {
            _gpio.Write((Int32)pinNumber, PinValue.High);
        }

        public void OpenPins(GpioController gpio, PinMode pinMode, int[] pins)
        {
            for (int i = 0; i < pins.Length; i++)
            {
                OpenPin(gpio, pinMode, pins[i]);
            }
        }

        public void OpenPin(GpioController gpio, PinMode pinMode, int pin)
        {
            gpio.OpenPin(pin, pinMode);
        }

        public void ClosePins(GpioController gpio, int[] pins)
        {
            for (int i = 0; i < pins.Length; i++)
            {
                ClosePin(gpio, pins[i]);
            }
        }

        public void ClosePin(GpioController gpio, int pin)
        {
            gpio.ClosePin(pin);
        }

    }
}