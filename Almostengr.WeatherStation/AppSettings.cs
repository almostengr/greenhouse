namespace Almostengr.WeatherStation
{
    public class AppSettings
    {
        public string DatabaseFile { get; set; } = "weather.db";
        public int ReadSensorInterval { get; set; } = 30;
        public int RetentionDays { get; set; } = 1825;
        public int PortNumber { get; set; } = 8080;
        public TwitterSettings Twitter { get; set; } = null;
    }

    public class TwitterSettings
    {
        public int UpdateInterval { get; set; } = 60;
        public string ConsumerKey { get; set; } = null;
        public string ConsumerSecret { get; set; } = null;
        public string AccessToken { get; set; } = null;
        public string AccessSecret { get; set; } = null;
    }
}