using System;
using System.ComponentModel.DataAnnotations;

namespace Almostengr.Greenhouse.Scheduler.Models
{
    public class BaseModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime Created { get; set; } = DateTime.Now;
    }
}