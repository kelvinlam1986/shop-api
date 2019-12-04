using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApi.Models
{
    public class PurchaseInvoiceBatch
    {
        [Key]
        [Column(Order = 1, TypeName = "varchar(3)")]
        public string Code { get; set; }

        [Required]
        [Column(Order = 2)]
        public DateTime BatchDate { get; set; }

        [Required]
        [Column(Order = 3, TypeName = "nvarchar(150)")]
        public string Description { get; set; }

        [Required]
        [Column(Order = 4)]
        public bool Status { get; set; }

        [Column(Order = 5, TypeName = "nvarchar(50)")]
        public string CreatedBy { get; set; }

        [Column(Order = 6)]
        public DateTime CreatedDate { get; set; }

        [Column(Order = 7, TypeName = "nvarchar(50)")]
        public string UpdatedBy { get; set; }

        [Column(Order = 8)]
        public DateTime UpdatedDate { get; set; }
    }
}