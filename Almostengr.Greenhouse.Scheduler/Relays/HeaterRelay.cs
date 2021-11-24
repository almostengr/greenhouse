using System.Device.Gpio;
using Almostengr.Greenhouse.Scheduler.Common;
using Almostengr.Greenhouse.Scheduler.Relays.Interfaces;

namespace Almostengr.Greenhouse.Scheduler.Relays
{
    public class HeaterRelay : BaseRelay, IHeaterRelay
    {
        public HeaterRelay(GpioController gpio) : base(gpio)
        {
        }

        public void TurnOff1()
        {
            base.TurnOff(GpioRelayPin.HeaterOne);
        }

        public void TurnOn1()
        {
            base.TurnOn(GpioRelayPin.HeaterOne);
        }
    }
}