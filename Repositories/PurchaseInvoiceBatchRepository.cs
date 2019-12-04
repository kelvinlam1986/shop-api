using System;
using System.Collections.Generic;
using System.Linq;
using ShopApi.Data;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public class PurchaseInvoiceBatchRepository : IPurchaseInvoiceBatchRepository
    {
        private ShopContext _context;

        public PurchaseInvoiceBatchRepository(ShopContext context)
        {
            this._context = context;
        }

        public IEnumerable<PurchaseInvoiceBatch> GetListByRangeAndCondition(DateTime startDate, DateTime endDate, int batchStatus, string username, string keyword, int page, int pageSize, out int totalRow)
        {
            totalRow = 0;
            IQueryable<PurchaseInvoiceBatch> query = null;
            query = this._context.PurchaseInvoiceBatches.Where(x => x.BatchDate >= startDate && x.BatchDate <= endDate);

            if (batchStatus == 0)
            {
                query = query.Where(x => x.Status == false);
            }
            else if (batchStatus == 1)
            {
                query = query.Where(x => x.Status == true);
            }

            if (!string.IsNullOrEmpty(username))
            {
                query = query.Where(x => x.CreatedBy == username);
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(
                    x => x.Code.Contains(keyword) ||
                    x.Description.Contains(keyword));
            }

            totalRow = query.Count();
            query = query.OrderByDescending(x => x.BatchDate)
                        .Skip(page * pageSize)
                        .Take(pageSize);

            return query.ToList();
        }

        public PurchaseInvoiceBatch GetByCode(string code)
        {
            return this._context.PurchaseInvoiceBatches.Find(code);
        }

        public bool Remove(PurchaseInvoiceBatch purchaseInvoiceBatch)
        {
            try
            {
                this._context.PurchaseInvoiceBatches.Remove(purchaseInvoiceBatch);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveByCode(string code)
        {
            try
            {
                var purchaseInvoiceBatch = this._context.PurchaseInvoiceBatches.Find(code);
                if (purchaseInvoiceBatch == null)
                {
                    return false;
                }

                this._context.PurchaseInvoiceBatches.Remove(purchaseInvoiceBatch);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Insert(PurchaseInvoiceBatch purchaseInvoiceBatch)
        {
            try
            {
                this._context.PurchaseInvoiceBatches.Add(purchaseInvoiceBatch);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(PurchaseInvoiceBatch purchaseInvoiceBatch)
        {
            try
            {
                this._context.PurchaseInvoiceBatches.Update(purchaseInvoiceBatch);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<PurchaseInvoiceBatch> GetAllWithoutPaging()
        {
            return this._context.PurchaseInvoiceBatches.OrderByDescending(x => x.BatchDate).ToList();
        }
    }
}