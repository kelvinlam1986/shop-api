using System.ComponentModel.DataAnnotations;

namespace ShopApi.ViewModels
{
    public class CustomerUpdateDTO
    {
        [Required(ErrorMessage = "Họ khách hàng cần được cung cấp.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Tên khách hàng cần được cung cấp.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Địa chỉ cần được cung cấp.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Số điện thoại cần được cung cấp.")]
        public string Contact { get; set; }
    }
}