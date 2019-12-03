using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApi.Models
{
    public class Province
    {
        [Key]
        [Column(Order = 1, TypeName = "char(3)")]
        public string Code { get; set; }

        [Required]
        [Column(Order = 2, TypeName = "nvarchar(30)")]
        public string Name { get; set; }

        [Required]
        [Column(Order = 3, TypeName = "char(3)")]
        public string CountryCode { get; set; }

        [ForeignKey(nameof(CountryCode))]
        public Country Country { get; set; }

        [Column(Order = 4, TypeName = "nvarchar(50)")]
        public string CreatedBy { get; set; }

        [Column(Order = 5)]
        public DateTime CreatedDate { get; set; }

        [Column(Order = 6, TypeName = "nvarchar(50)")]
        public string UpdatedBy { get; set; }

        [Column(Order = 7)]
        public DateTime UpdatedDate { get; set; }
    }
}