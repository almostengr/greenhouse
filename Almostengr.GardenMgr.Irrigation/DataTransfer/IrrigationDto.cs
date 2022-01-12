using System;
using System.ComponentModel.DataAnnotations;

namespace Almostengr.GardenMgr.Irrigation.Api.DataTransfer
{
    public class IrrigationDto
    {
        public int Id { get; set; }

        [Required]
        [Range(1, 100)]
        public double Amount { get; set; }

        public DateTime Created { get; set; }

        [Required]
        public int ZoneId { get; set; }
    }
}