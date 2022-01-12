using Almostengr.GardenMgr.Common.Relays;

namespace Almostengr.GardenMgr.Irrigation.Relays
{
    public interface IIrrigationRelay : IBaseRelay
    {
        void TurnOnWater();
        void TurnOffWater();
    }
}