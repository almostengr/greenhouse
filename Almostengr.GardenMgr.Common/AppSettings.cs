using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Almostengr.WeatherStation.Api
{
    public class AppSettings
    {
        public string DatabaseFile { get; set; } = "weather.db";
        public int ReadSensorInterval { get; set; } = 30;
        public int RetentionDays { get; set; } = 1825;
        public TwitterSettings Twitter { get; set; } = null;
        public WeatherSettings Weather { get; set; } = null;
        public IrrigationSettings Irrigation { get; set; } = null;
    }

    public class WeatherSettings
    {
        public int ReadSensorInterval { get; set; } = 30;
        public int PortNumber {get;set;} = 8080;
    }

    public class TwitterSettings
    {
        public int UpdateInterval { get; set; } = 60;
        public string ConsumerKey { get; set; } = null;
        public string ConsumerSecret { get; set; } = null;
        public string AccessToken { get; set; } = null;
        public string AccessSecret { get; set; } = null;
    }

    public class IrrigationSettings
    {
        public List<IrrigationZone> Zones { get; set; } = null;
        public int PortNumber { get; set; } = 8081;
    }

    public class IrrigationZone
    {
        public int ZoneId { get; set; }

        [Range(1,27)]
        public int ValveGpioPin { get; set; }

        [Range(1,27)]
        public int SensorGpioPin { get; set; }

        [Range(0.5, 120)]
        public double WateringTime { get; set; } = 5.0;

        [Range(0, 120)]
        public int ReadSensorInterval { get; set; } = 30;
    }
}