using System.ComponentModel.DataAnnotations;

namespace ShopApi.ViewModels
{
    public class CountryAddDTO
    {
        [Required(ErrorMessage = "Mã quốc gia cần được cung cấp.")]
        [StringLength(3, ErrorMessage = "Mã quốc gia tối đa 3 ký tự")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Tên quốc gia cần được cung cấp.")]
        public string Name { get; set; }
    }
}