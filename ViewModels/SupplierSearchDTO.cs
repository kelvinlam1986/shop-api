namespace ShopApi.ViewModels
{
    public class SupplierSearchDTO
    {
        public int BranchId { get; set; }
        public string Keyword { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

    }
}