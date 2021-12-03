using System;
using System.Collections.Generic;

namespace Almostengr.Greenhouse.Api.DataTransferObjects
{
    public class NwsObservationDto : BaseDto
    {
        public List<NwsFeature> Features { get; set; }
    }

    public class NwsObservationLatestDto : BaseDto
    {
        public List<NwsProperties> Properties { get; set; }
    }

    public class NwsFeature
    {
        public NwsProperties Properties { get; set; }
    }

    public class NwsProperties
    {
        public DateTime Timestamp { get; set; }
        public NwsPrecipitationLastHour PrecipitationLastHour { get; set; }
        public NwsTemperature Temperature { get; set; }
        public NwsRelativeHumidity RelativeHumidity { get; set; }
        public string Station { get; set; }
    }

    public class NwsPrecipitationLastHour
    {
        public double? Value { get; set; } = 0.0;
        public string UnitCode { get; set; }
    }

    public class NwsTemperature
    {
        public double? Value { get; set; } = 0.0;
        public string UnitCode { get; set; }
    }

    public class NwsRelativeHumidity
    {
        public double? Value { get; set; } = 0.0;
        public string UnitCode { get; set; }
    }
}