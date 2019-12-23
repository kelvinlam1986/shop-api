using System.ComponentModel.DataAnnotations;

namespace ShopApi.ViewModels
{
    public class BankAddDTO
    {
        [Required(ErrorMessage = "Mã ngân hàng cần được cung cấp.")]
        [StringLength(3, ErrorMessage = "Mã ngân hàng tối đa 3 ký tự")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Tên ngân hàng cần được cung cấp.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Địa chỉ ngân hàng cần được cung cấp.")]
        public string Address { get; set; }
    }
}