using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Almostengr.Greenhouse.Scheduler.Common
{
    public class AppSettings
    {
        public Twitter Twitter { get; set; }
        public List<int> WaterRelayGpios { get; set; }
        public List<int> WaterSensorGpios { get; set; }
        public int WateringTime { get; set; }
        public List<string> WeatherStationUrls { get; set; }
        public string ConnectionString { get; internal set; }
    }

    public class Twitter
    {
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
        public string AccessToken { get; set; }
        public string AccessSecret { get; set; }
        public string Prefix { get; set; }
        public string AlarmUsers { get; set; }
    }
}