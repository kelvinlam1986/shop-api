using System.Collections.Generic;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public interface IReceiptTypeRepository
    {
        IEnumerable<ReceiptType> GetAll(string keyword, int page, int pageSize, out int totalRow);
        ReceiptType GetByCode(string code);
        bool Update(ReceiptType receiptType);
        bool Insert(ReceiptType receiptType);
        bool Remove(ReceiptType receiptType);
        bool RemoveByCode(string code);
        bool CheckExisting(string code, string name);
        IEnumerable<ReceiptType> GetAllWithoutPaging();
    }
}