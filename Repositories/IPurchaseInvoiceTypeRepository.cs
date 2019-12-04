using System.Collections.Generic;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public interface IPurchaseInvoiceTypeRepository
    {
        IEnumerable<PurchaseInvoiceType> GetAll(string keyword, int page, int pageSize, out int totalRow);
        PurchaseInvoiceType GetByCode(string code);
        bool Update(PurchaseInvoiceType purchaseInvoiceType);
        bool Insert(PurchaseInvoiceType purchaseInvoiceType);
        bool Remove(PurchaseInvoiceType purchaseInvoiceType);
        bool RemoveByCode(string code);
        bool CheckExisting(string code, string name);
        IEnumerable<PurchaseInvoiceType> GetAllWithoutPaging();
    }
}