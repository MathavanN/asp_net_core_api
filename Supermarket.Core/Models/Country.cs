using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.Core.Models
{
    public class Country : IEntity
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime DateModified { get; set; }
    }
}
