using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Supermarket.Core.Models
{
    public class Payment : IEntity
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string  BillNumber { get; set; }

        public int PaymentTypeId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal DeductedPoints { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmountPaid { get; set; }

        public DateTime PaymentDate { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime DateModified { get; set; }
    }
}
