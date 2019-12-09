using System.ComponentModel.DataAnnotations;

namespace ShopApi.ViewModels
{
    public class BankUpdateDTO
    {
        [Required(ErrorMessage = "Mã ngân hàng cần được cung cấp.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Tên ngân hàng cần được cung cấp.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Địa chỉ ngân hàng cần được cung cấp.")]
        public string Address { get; set; }
    }
}