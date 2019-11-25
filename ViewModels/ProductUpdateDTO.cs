using System.ComponentModel.DataAnnotations;

namespace ShopApi.ViewModels
{
    public class ProductUpdateDTO
    {
        [Required(ErrorMessage = "Bạn phải nhập Mã sản phẩm.")]
        public string Serial { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm cần được cung cấp.")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Bạn phải chọn một loại sản phẩm.")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Bạn phải chọn một nhà cung cấp.")]
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập giá sản phẩm")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập Thứ tự sắp xếp")]
        public int ReOrder { get; set; }
    }
}