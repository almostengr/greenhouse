namespace Almostengr.Greenhouse.Api.Relays.Interfaces
{
    public interface IHeaterRelay : IBaseRelay
    {
        void TurnOn();
        void TurnOff();
    }
}