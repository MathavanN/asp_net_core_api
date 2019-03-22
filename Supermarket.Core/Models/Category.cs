using System;
using System.Collections.Generic;

namespace Supermarket.Core.Models
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Product> Products { get; set; } = new List<Product>();
        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }
    }
}
