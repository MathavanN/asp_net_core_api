using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket.Core.Models
{
    public class SupplierCategory : IEntity
    {
        public int Id { get; set; }

        public int  SupplierId { get; set; }

        public int CategoryId { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime DateModified { get; set; }
    }
}
