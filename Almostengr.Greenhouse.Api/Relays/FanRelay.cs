using System;
using System.Device.Gpio;
using Almostengr.Greenhouse.Api.Common;
using Almostengr.Greenhouse.Api.Relays.Interfaces;

namespace Almostengr.Greenhouse.Api.Relays
{
    public class FanRelay : BaseRelay, IFanRelay
    {
        private readonly GpioController _gpio;

        public FanRelay(GpioController gpio) : base(gpio)
        {
            _gpio = gpio;
            OpenPins(gpio, PinMode.Output, new Int32[] { (Int32)GpioRelayPin.FanOne, (Int32)GpioRelayPin.FanTwo });
        }

        public void TurnOn()
        {
            base.TurnOn(GpioRelayPin.FanOne);
        }

        public void TurnOff()
        {
            base.TurnOff(GpioRelayPin.FanOne);
        }

    }
}