using System;
using System.ComponentModel.DataAnnotations;

namespace Almostengr.Greenhouse.Api.Models
{
    public class BaseModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime Created { get; set; }
    }
}