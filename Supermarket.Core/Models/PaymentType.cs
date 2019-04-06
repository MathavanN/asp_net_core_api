using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.Core.Models
{
    class PaymentType : IEntity
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string PayementType { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime DateModified { get; set; }
    }
}
