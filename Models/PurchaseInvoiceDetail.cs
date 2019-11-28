using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApi.Models
{
    public class PurchaseInvoiceDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int InvoiceSystemId { get; set; }

        [Required]
        [Column(Order = 1, TypeName = "varchar(10)")]
        public string InvoiceId { get; set; }

        [ForeignKey(nameof(InvoiceSystemId))]
        public PurchaseInvoice Invoice { get; set; }

        [Required]
        [Column(Order = 2)]
        public int OrdinalNumber { get; set; }

        [Required]
        [Column(Order = 3)]
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        [Required]
        [Column(Order = 4, TypeName = "decimal(10,2)")]
        public decimal Quantity { get; set; }

        [Required]
        [Column(Order = 5, TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Required]
        [Column(Order = 6, TypeName = "decimal(10,2)")]
        public decimal VATRate { get; set; }

        [Required]
        [Column(Order = 7, TypeName = "decimal(10,2)")]
        public decimal ImportTaxtRate { get; set; }

        [Column(Order = 8, TypeName = "nvarchar(50)")]
        public string CreatedBy { get; set; }

        [Column(Order = 9)]
        public DateTime CreatedDate { get; set; }

        [Column(Order = 10, TypeName = "nvarchar(50)")]
        public string UpdatedBy { get; set; }

        [Column(Order = 11)]
        public DateTime UpdatedDate { get; set; }

        [Required]
        [Column(Order = 12)]
        public int BranchId { get; set; }

        [ForeignKey(nameof(BranchId))]
        public Branch Branch { get; set; }
    }
}