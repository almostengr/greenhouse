namespace Almostengr.GardenMgr.Api.Relays
{
    public interface IPlantWateringRelay : IBaseRelay
    {
        void TurnOnWater(int waterGpioNumber, int pumpGpioNumber);
        void TurnOffWater(int waterGpioNumber, int pumpGpioNumber);
        void OpenGpio(int gpioNumber);
        void CloseGpio(int gpioNumber);
    }
}