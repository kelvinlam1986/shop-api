using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApi.Models
{
    public class Report
    {
        [Key]
        [Column(Order = 1, TypeName = "nvarchar(50)")]
        public string ReportName { get; set; }

        [Column(Order = 2, TypeName = "nvarchar(50)")]
        public string DataSheet { get; set; }

        [Column(Order = 3, TypeName = "nvarchar(50)")]
        public string SingleForm { get; set; }

        [Column(Order = 4, TypeName = "nvarchar(50)")]
        public string RelationTables { get; set; }
    }
}