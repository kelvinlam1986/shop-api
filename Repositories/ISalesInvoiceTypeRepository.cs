using System.Collections.Generic;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public interface ISalesInvoiceTypeRepository
    {
        IEnumerable<SalesInvoiceType> GetAll(string keyword, int page, int pageSize, out int totalRow);
        SalesInvoiceType GetByCode(string code);
        bool Update(SalesInvoiceType receiptType);
        bool Insert(SalesInvoiceType receiptType);
        bool Remove(SalesInvoiceType receiptType);
        bool RemoveByCode(string code);
        bool CheckExisting(string code, string name);
        IEnumerable<SalesInvoiceType> GetAllWithoutPaging();
    }
}