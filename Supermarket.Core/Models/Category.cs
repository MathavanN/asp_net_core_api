using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.Core.Models
{
    public class Category : IEntity
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
        public IList<Product> Products { get; set; } = new List<Product>();
        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }
    }
}
