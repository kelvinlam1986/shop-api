using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApi.Models
{
    public class Manufacture
    {
        [Key]
        [Column(Order = 1, TypeName = "char(5)")]
        public string Code { get; set; }

        [Required]
        [Column(Order = 2, TypeName = "nvarchar(30)")]
        public string Name { get; set; }

        [Required]
        [Column(Order = 3, TypeName = "nvarchar(50)")]
        public string Address { get; set; }

        [Required]
        [Column(Order = 4, TypeName = "char(3)")]
        public string CountryId { get; set; }

        [ForeignKey(nameof(CountryId))]
        public Country Country { get; set; }

        [Column(Order = 5)]
        public DateTime DueDate { get; set; }

        [Column(Order = 6, TypeName = "nvarchar(50)")]
        public string CreatedBy { get; set; }

        [Column(Order = 7)]
        public DateTime CreatedDate { get; set; }

        [Column(Order = 8, TypeName = "nvarchar(50)")]
        public string UpdatedBy { get; set; }

        [Column(Order = 9)]
        public DateTime UpdatedDate { get; set; }
    }
}