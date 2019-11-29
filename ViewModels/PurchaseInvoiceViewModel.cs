using System;

namespace ShopApi.ViewModels
{
    public class PurchaseInvoiceViewModel
    {
        public int Approval { get; set; }
        public int Status { get; set; }
        public string InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string CurrencyId { get; set; }
        public string CreatedBy { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal Amount { get; set; }
        public string DescriptionInVietNamese { get; set; }
    }
}