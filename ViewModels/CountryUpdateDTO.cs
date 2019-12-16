using System.ComponentModel.DataAnnotations;

namespace ShopApi.ViewModels
{
    public class CountryUpdateDTO
    {
        [Required(ErrorMessage = "Mã quốc gia cần được cung cấp.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Tên quốc gia cần được cung cấp.")]
        public string Name { get; set; }
    }
}