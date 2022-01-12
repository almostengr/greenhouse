using System;
using System.ComponentModel.DataAnnotations;
using Almostengr.GardenMgr.Common.Models;

namespace Almostengr.GardenMgr.Irrigation.DataTransfer
{
    public class PlantWateringDto
    {
        public PlantWateringDto(PlantWatering plantWatering)
        {
        }

        public int Id { get; set; }

        [Required]
        [Range(1, 100)]
        public double Amount { get; set; }

        public DateTime Created { get; set; }

        [Required]
        public int ZoneId { get; set; }

        internal PlantWatering ToPlantWatering()
        {
            throw new NotImplementedException();
        }
    }
}