namespace Almostengr.Greenhouse.Api.Relays.Interfaces
{
    public interface IFanRelay : IBaseRelay
    {
        void TurnOn();
        void TurnOff();
    }
}