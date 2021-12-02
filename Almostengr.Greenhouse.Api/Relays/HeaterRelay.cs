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

        public void TurnOff()
        {
            base.TurnOff(GpioRelayPin.HeaterOne);
        }

        public void TurnOn()
        {
            base.TurnOn(GpioRelayPin.HeaterOne);
        }
    }
}