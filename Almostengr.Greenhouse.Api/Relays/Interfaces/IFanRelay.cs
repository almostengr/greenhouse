namespace Almostengr.Greenhouse.Api.Relays.Interfaces
{
    public interface IFanRelay : IBaseRelay
    {
        void TurnOnFan1();
        void TurnOffFan1();
        void TurnOnFan2();
        void TurnOffFan2();
    }
}