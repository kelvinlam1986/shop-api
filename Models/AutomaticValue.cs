using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApi.Models
{
    public class AutomaticValue
    {
        [Key]
        [Column(Order = 1, TypeName = "nvarchar(50)")]
        public string ObjectName { get; set; }

        [Required]
        [Column(Order = 2, TypeName = "nvarchar(50)")]
        public string PrefixOfDefaultValueForId { get; set; }

        [Required]
        [Column(Order = 3)]
        public int LengthOfDefaultValueForId { get; set; }

        [Required]
        [Column(Order = 4, TypeName = "nvarchar(50)")]
        public string LastValueOfColumnId { get; set; }
    }
}