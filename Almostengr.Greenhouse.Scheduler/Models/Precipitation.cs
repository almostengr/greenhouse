using System;
using System.ComponentModel.DataAnnotations;
using Almostengr.Greenhouse.Scheduler.DataTransferObject;

namespace Almostengr.Greenhouse.Scheduler.Models
{
    public class Precipitation : BaseModel
    {
        public Precipitation()
        {
            this.Created = DateTime.Now;
        }

        public Precipitation(NwsObservationLatestDto dto)
        {
            Created = dto.Properties[0].Timestamp;
            Amount = (double)dto.Properties[0].PrecipitationLastHour.Value;
            Unit = dto.Properties[0].PrecipitationLastHour.UnitCode;
            Location = dto.Properties[0].Station;
        }

        [Required]
        public double Amount { get; set; }

        [Required]
        public string Unit { get; set; }

        public string Location { get; set; }

    }
}