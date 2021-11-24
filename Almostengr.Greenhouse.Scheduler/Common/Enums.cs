namespace Almostengr.Greenhouse.Scheduler.Common
{
    public enum TemperatureSource
    {
        NWS = 1,
        Ds18b20 = 2
    }

    public enum GpioRelayPin
    {
        FanOne = 14,
        FanTwo = 15,
        WaterOne = 17,
        WaterTwo = 18,
        HeaterOne = 5,
    }
}