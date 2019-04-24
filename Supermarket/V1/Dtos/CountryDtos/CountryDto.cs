using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.V1.Dtos.CountryDtos
{
    public class CountryDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime DateModified { get; set; }
    }
}
