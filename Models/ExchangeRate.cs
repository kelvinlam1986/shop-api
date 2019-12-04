using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApi.Models
{
    public class ExchangeRate
    {
        [Column(Order = 1, TypeName = "char(3)")]
        public string CurrencyCode { get; set; }

        [ForeignKey(nameof(CurrencyCode))]
        public Currency Currency { get; set; }

        [Column(Order = 2)]
        public DateTime DateOfRate { get; set; }

        [Required]
        [Column(Order = 3, TypeName = "decimal(10,2)")]
        public decimal Rate { get; set; }

        [Column(Order = 4)]
        public bool Discontinued { get; set; }

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