using System.Device.Gpio;

namespace Almostengr.GardenMgr.Api.Relays
{
    public class PlantWateringRelay : BaseRelay, IPlantWateringRelay
    {
        public readonly GpioController _gpio;

        public PlantWateringRelay(GpioController gpio) : base(gpio)
        {
            _gpio = gpio;
            // OpenPins(gpio, PinMode.Output, new Int32[] { (Int32)GpioRelayPin.WaterOne, (Int32)GpioRelayPin.WaterTwo });

            // foreach (var zone in appSettings.Irrigation.Zones)
            // {
            //     OpenPin(gpio, PinMode.Output, zone.WaterGpioNumber);

            //     if (zone.PumpGpioNumber > 0)
            //     {
            //         OpenPin(gpio, PinMode.Output, zone.PumpGpioNumber);
            //     }
            // }
        }

        public void CloseGpio(int gpioNumber)
        {
            base.ClosePin(gpioNumber);
        }

        public void OpenGpio(int gpioNumber)
        {
            base.OpenPin(PinMode.Output, gpioNumber);
        }

        public void TurnOffWater(int waterGpioNumber, int pumpGpioNumber)
        {
            base.TurnOff(waterGpioNumber);

            if (pumpGpioNumber > 0)
            {
                base.TurnOff(pumpGpioNumber);
            }
        }

        public void TurnOnWater(int waterGpioNumber, int pumpGpioNumber)
        {
            if (pumpGpioNumber > 0)
            {
                base.TurnOn(pumpGpioNumber);
            }

            base.TurnOn(waterGpioNumber);
        }

    }
}