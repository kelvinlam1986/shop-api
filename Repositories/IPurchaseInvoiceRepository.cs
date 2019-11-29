using System.Collections.Generic;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public interface IPurchaseInvoiceRepository
    {
        IEnumerable<PurchaseInvoiceQuery> GetPurchaseInvoicesList(int supplierId, int invoiceStatus, string username);
    }
}