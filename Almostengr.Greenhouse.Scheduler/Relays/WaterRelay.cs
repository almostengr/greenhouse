using System;
using System.Device.Gpio;
using Almostengr.Greenhouse.Scheduler.Common;
using Almostengr.Greenhouse.Scheduler.Relays.Interfaces;

namespace Almostengr.Greenhouse.Scheduler.Relays
{
    public class WaterRelay : BaseRelay, IWaterRelay
    {
        public readonly GpioController _gpio;

        public WaterRelay(GpioController gpio) : base(gpio)
        {
            _gpio = gpio;
            OpenPins(gpio, PinMode.Output, new Int32[] { (Int32)GpioRelayPin.WaterOne, (Int32)GpioRelayPin.WaterTwo });
        }

        public void TurnOffWater1()
        {
            base.TurnOff(GpioRelayPin.WaterOne);
        }

        public void TurnOffWater2()
        {
            base.TurnOff(GpioRelayPin.WaterTwo);
        }

        public void TurnOnWater1()
        {
            base.TurnOn(GpioRelayPin.WaterOne);
        }

        public void TurnOnWater2()
        {
            base.TurnOn(GpioRelayPin.WaterTwo);
        }

    }
}