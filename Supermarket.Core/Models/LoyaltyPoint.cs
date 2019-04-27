using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.Core.Models
{
    public class LoyaltyPoint : IEntity
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string PointDetail { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Point { get; set; }

        public bool IsExpired { get; set; }

        public DateTime PointDate { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime DateModified { get; set; }
    }
}
