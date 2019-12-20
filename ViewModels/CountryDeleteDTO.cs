using System.ComponentModel.DataAnnotations;

namespace ShopApi.ViewModels
{
    public class CountryDeleteDTO
    {
        [Required(ErrorMessage = "Mã quốc gia cần được cung cấp.")]
        public string Code { get; set; }
    }
}