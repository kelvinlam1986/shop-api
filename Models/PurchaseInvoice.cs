using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApi.Models
{
    public class PurchaseInvoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(Order = 1, TypeName = "varchar(10)")]
        public string InvoiceId { get; set; }

        [Required]
        [Column(Order = 2)]
        public DateTime InvoiceDate { get; set; }

        [Required]
        [Column(Order = 3, TypeName = "varchar(3)")]
        public string InvoiceTypeId { get; set; }

        [Required]
        [Column(Order = 4)]
        public int SupplierId { get; set; }

        [ForeignKey(nameof(SupplierId))]
        public Supplier Supplier { get; set; }

        [Required]
        [Column(Order = 5, TypeName = "varchar(3)")]
        public string CurrencyId { get; set; }

        [Required]
        [Column(Order = 6, TypeName = "decimal(10,2)")]
        public decimal ExchangeRate { get; set; }

        [Required]
        [Column(Order = 7)]
        public bool InvoiceStatus { get; set; }

        [Required]
        [Column(Order = 8, TypeName = "nvarchar(150)")]
        public string DescriptionInVietNamese { get; set; }

        [Column(Order = 9, TypeName = "nvarchar(50)")]
        public string CreatedBy { get; set; }

        [Column(Order = 10)]
        public DateTime CreatedDate { get; set; }

        [Column(Order = 11, TypeName = "nvarchar(50)")]
        public string UpdatedBy { get; set; }

        [Column(Order = 12)]
        public DateTime UpdatedDate { get; set; }

        [Required]
        [Column(Order = 13)]
        public int BranchId { get; set; }

        [ForeignKey(nameof(BranchId))]
        public Branch Branch { get; set; }

    }
}