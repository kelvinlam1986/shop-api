using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApi.Models
{
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(Order = 1, TypeName = "char(5)")]
        public string Code { get; set; }

        [Required]
        [Column(Order = 2, TypeName = "nvarchar(150)")]
        public string VietnameseName { get; set; }

        [Column(Order = 3, TypeName = "nvarchar(150)")]
        public string OtherLanguageName { get; set; }

        [Required]
        [Column(Order = 4, TypeName = "char(3)")]
        public string SupplierTypeCode { get; set; }

        [ForeignKey(nameof(SupplierTypeCode))]
        public SupplierType SupplierType { get; set; }

        [Column(Order = 5, TypeName = "char(3)")]
        public string ProvinceCode { get; set; }

        [ForeignKey(nameof(ProvinceCode))]
        public Province Province { get; set; }

        [Required]
        [Column(Order = 6, TypeName = "nvarchar(50)")]
        public string ContactName { get; set; }

        [Required]
        [Column(Order = 7, TypeName = "nvarchar(50)")]
        public string ContactTitle { get; set; }

        [Column(Order = 8, TypeName = "varchar(50)")]
        public string EmailAddress { get; set; }

        [Required]
        [Column(Order = 9, TypeName = "nvarchar(300)")]
        public string Address { get; set; }

        [Column(Order = 10, TypeName = "varchar(20)")]
        public string Telephone { get; set; }

        [Column(Order = 10, TypeName = "varchar(20)")]
        public string FaxNumber { get; set; }

        [Column(Order = 11, TypeName = "decimal(18,2)")]
        public decimal MaxDebitAmount { get; set; }

        [Column(Order = 12)]
        public DateTime DueDate { get; set; }

        [Column(Order = 13)]
        public bool Discontinued { get; set; }

        [Column(Order = 14, TypeName = "nvarchar(50)")]
        public string CreatedBy { get; set; }

        [Column(Order = 15)]
        public DateTime CreatedDate { get; set; }

        [Column(Order = 16, TypeName = "nvarchar(50)")]
        public string UpdatedBy { get; set; }

        [Column(Order = 17)]
        public DateTime UpdatedDate { get; set; }
    }
}