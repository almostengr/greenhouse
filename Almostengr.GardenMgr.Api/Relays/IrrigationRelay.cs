using System.Device.Gpio;
using Almostengr.GardenMgr.Api;
using Almostengr.GardenMgr.Api.Relays;

namespace Almostengr.GardenMgr.Api.Relays
{
    public class IrrigationRelay : BaseRelay, IIrrigationRelay
    {
        public readonly GpioController _gpio;

        public IrrigationRelay(GpioController gpio, AppSettings appSettings) : base(gpio)
        {
            _gpio = gpio;
            // OpenPins(gpio, PinMode.Output, new Int32[] { (Int32)GpioRelayPin.WaterOne, (Int32)GpioRelayPin.WaterTwo });

            foreach (var zone in appSettings.Irrigation.Zones)
            {
                OpenPin(gpio, PinMode.Output, zone.ValveGpioNumber);

                if (zone.PumpGpioNumber > 0)
                {
                    OpenPin(gpio, PinMode.Output, zone.PumpGpioNumber);
                }
            }

        }

        public void TurnOffWater(int pin)
        {
            base.TurnOff(pin);
        }

        public void TurnOnWater(int pin)
        {
            base.TurnOn(pin);
        }

        public void TurnOffPump(int pin)
        {
            if (pin > 0)
            {
                base.TurnOff(pin);
            }
        }
        
        public void TurnOnPump(int pin)
        {
            if (pin > 0)
            {
                base.TurnOn(pin);
            }
        }

    }
}