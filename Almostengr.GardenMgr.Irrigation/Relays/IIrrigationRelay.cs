using Almostengr.GardenMgr.Common.Relays;

namespace Almostengr.GardenMgr.Irrigation.Relays
{
    public interface IIrrigationRelay : IBaseRelay
    {
        void TurnOnWater(int valveGpioNumber);
        void TurnOffWater(int valveGpioNumber);
        void TurnOnPump(int pumpGpioNumber);
        void TurnOffPump(int pumpGpioNumber);
    }
}