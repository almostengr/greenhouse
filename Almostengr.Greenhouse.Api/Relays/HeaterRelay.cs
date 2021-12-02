using System.Device.Gpio;
using Almostengr.Greenhouse.Api.Common;
using Almostengr.Greenhouse.Api.Relays.Interfaces;

namespace Almostengr.Greenhouse.Api.Relays
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