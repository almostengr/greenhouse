namespace Almostengr.Greenhouse.Api.Relays.Interfaces
{
    public interface IIrrigationRelay : IBaseRelay
    {
        void TurnOnWater1();
        void TurnOffWater1();
        void TurnOnWater2();
        void TurnOffWater2();
    }
}