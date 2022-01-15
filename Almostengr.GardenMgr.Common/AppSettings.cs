using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Almostengr.GardenMgr.Common
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
        public int RainGaugeGpioNumber { get; set; } = 0;
        public int TweetInterval { get; set; } = 60;
    }

    public class TwitterSettings
    {
        public List<string> Users { get; set; } = null;
        public string ConsumerKey { get; set; } = null;
        public string ConsumerSecret { get; set; } = null;
        public string AccessToken { get; set; } = null;
        public string AccessSecret { get; set; } = null;
    }

    public class IrrigationSettings
    {
        public List<IrrigationZoneSettings> Zones { get; set; } = null;
    }

    public class IrrigationZoneSettings
    {
        [Required]
        public int ZoneId { get; set; }

        [Range(0, 27)]
        public int ValveGpioNumber { get; set; } = 0;

        public double WateringDuration { get; set; } = 5.0;

        public TimeSpan WateringTime { get; set; } = new TimeSpan(6, 0, 0);

        [Range(0, 27)]
        public int PumpGpioNumber { get; set; } = 0;
        public string Name { get; set; }
    }
}