using System;
using System.Collections.Generic;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public interface IPurchaseInvoiceBatchRepository
    {
        IEnumerable<PurchaseInvoiceBatch> GetListByRangeAndCondition(
            DateTime startDate, DateTime endDate, int batchStatus, string username, string keyword, int page, int pageSize, out int totalRow);
        PurchaseInvoiceBatch GetByCode(string code);
        bool Remove(PurchaseInvoiceBatch purchaseInvoiceBatch);
        bool RemoveByCode(string code);
        bool Update(PurchaseInvoiceBatch purchaseInvoiceBatch);
        bool Insert(PurchaseInvoiceBatch purchaseInvoiceBatch);
        IEnumerable<PurchaseInvoiceBatch> GetAllWithoutPaging();
    }
}