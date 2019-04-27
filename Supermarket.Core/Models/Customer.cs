using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Supermarket.Core.Models
{
    class Customer : IEntity
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(256)")]
        public string FisrtName { get; set; }

        [Column(TypeName = "varchar(256)")]
        public string MiddleName { get; set; }

        [Column(TypeName = "varchar(256)")]
        public string LastName { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string Address { get; set; }

        public int CountyId { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Mobile { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Passport { get; set; }

        [Column(TypeName = "varchar(256)")]
        public string Email { get; set; }

        public bool PromotionDetailsToMobile { get; set; }

        public bool PromotionDetailsToEmail { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime DateModified { get; set; }

        public Country Country { get; set; }

    }
}
