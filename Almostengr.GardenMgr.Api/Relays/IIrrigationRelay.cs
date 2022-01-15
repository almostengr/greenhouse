using Almostengr.GardenMgr.Api.Relays;

namespace Almostengr.GardenMgr.Api.Relays
{
    public interface IIrrigationRelay : IBaseRelay
    {
        void TurnOnWater(int valveGpioNumber);
        void TurnOffWater(int valveGpioNumber);
        void TurnOnPump(int pumpGpioNumber);
        void TurnOffPump(int pumpGpioNumber);
    }
}