using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Almostengr.GardenMgr.Api
{
    public class AppSettings
    {
        public string DatabaseFile { get; set; } = "/var/tmp/weather.db";
        public int RetentionDays { get; set; } = 1825;
        public TwitterSettings Twitter { get; set; } = new();
        public WeatherSettings Weather { get; set; } = new();
        public IrrigationSettings Irrigation { get; set; } = new();
    }

    public class WeatherSettings
    {
        public double ReadTemperatureInterval { get; set; } = 0.16; // 0.016; // 30;
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
        public List<IrrigationZoneSettings> Zones { get; set; } = new();
    }

    public class IrrigationZoneSettings
    {
        [Required]
        public int ZoneId { get; set; }

        [Range(0, 27)]
        public int WaterGpioNumber { get; set; } = 0;

        public double WateringDuration { get; set; } = 5.0;

        public TimeSpan WateringTime { get; set; } = new TimeSpan(6, 0, 0);

        public List<int> WateringDays { get; set; } = new List<int> { 7 };

        [Range(0, 27)]
        public int PumpGpioNumber { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
    }
}