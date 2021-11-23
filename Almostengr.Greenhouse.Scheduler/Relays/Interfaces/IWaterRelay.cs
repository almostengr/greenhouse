namespace Almostengr.Greenhouse.Scheduler.Relays.Interfaces
{
    public interface IWaterRelay : IBaseRelay
    {
        void TurnOnWater1();
        void TurnOffWater1();
        void TurnOnWater2();
        void TurnOffWater2();
    }
}