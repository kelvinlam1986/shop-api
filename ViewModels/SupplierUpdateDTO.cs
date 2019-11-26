using System.ComponentModel.DataAnnotations;

namespace ShopApi.ViewModels
{
    public class SupplierUpdateDTO
    {
        [Required(ErrorMessage = "Họ và tên cần được cung cấp.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Địa chỉ cần được cung cấp.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Số điện thoại cần được cung cấp.")]
        public string Contact { get; set; }
    }
}