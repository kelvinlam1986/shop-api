namespace ShopApi.ViewModels {
    public class ProductViewModel {
        public int Id { get; set; }
        public string Serial { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int Reorder { get; set; }
        public string Picture { get; set; }
    }
}