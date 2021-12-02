namespace Almostengr.Greenhouse.Api.Relays.Interfaces
{
    public interface IIrrigationRelay : IBaseRelay
    {
        void TurnOnWater();
        void TurnOffWater();
    }
}