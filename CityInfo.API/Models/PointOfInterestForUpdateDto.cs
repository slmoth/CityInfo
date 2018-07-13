using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Models
{
    public class PointOfInterestForUpdateDto
    {
        [Required(ErrorMessage = "Name is a required field.")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is a required field.")]
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
