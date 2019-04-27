using System;
using System.ComponentModel.DataAnnotations;

namespace Supermarket.V1.Dtos.CountryDtos
{
    public class CreateCountryDto
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public DateTime DateAdded { get; private set; } = DateTime.Now;

        public DateTime DateModified { get; private set; } = DateTime.Now;
    }
}
