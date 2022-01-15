using System;
using System.ComponentModel.DataAnnotations;

namespace Almostengr.GardenMgr.Common.Models
{
    public class Observation : ModelBase
    {
        [Key]
        public int ObservationId { get; set; }

        [Required]
        public double TemperatureC { get; set; }

        public double? HumidityPct { get; set; }
        public double? PressureMb { get; set; }

        [Required]
        public DateTime Created { get; set; }

    }
}
