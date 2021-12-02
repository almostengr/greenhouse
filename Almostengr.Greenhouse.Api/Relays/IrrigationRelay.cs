using System;
using System.Device.Gpio;
using Almostengr.Greenhouse.Api.Common;
using Almostengr.Greenhouse.Api.Relays.Interfaces;

namespace Almostengr.Greenhouse.Api.Relays
{
    public class IrrigationRelay : BaseRelay, IIrrigationRelay
    {
        public readonly GpioController _gpio;

        public IrrigationRelay(GpioController gpio) : base(gpio)
        {
            _gpio = gpio;
            OpenPins(gpio, PinMode.Output, new Int32[] { (Int32)GpioRelayPin.WaterOne, (Int32)GpioRelayPin.WaterTwo });
        }

        public void TurnOffWater()
        {
            base.TurnOff(GpioRelayPin.WaterOne);
        }

        public void TurnOnWater()
        {
            base.TurnOn(GpioRelayPin.WaterOne);
        }

    }
}