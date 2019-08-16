using System.ComponentModel.DataAnnotations;

namespace ShopApi.ViewModels
{
    public class CategoryAddDTO
    {
        [Required(ErrorMessage = "Tên loại sản phẩm cần được cung cấp.")]
        public string Name { get; set; }
    }
}