namespace Almostengr.Greenhouse.Api.Common
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

    public enum SettingKey {
        WorkerDelayMinutes,
        TwitterPrefix,
        TwitterConsumerKey,
        TwitterConsumerSecret,
        TwitterAccessToken,
        TwitterAccessTokenSecret,
        TwitterAlarmUsers,
        WaterRelayGpios,
        WaterSensorGpios,
        WeatherStationUrls,
        CoolingTargetTemperatureF,
        HeatingTargetTemperatureF,
        CoolingAlarmTemperatureF,
        HeatingAlarmTemperatureF,
    }
}