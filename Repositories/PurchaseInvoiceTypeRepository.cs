using System;
using System.Collections.Generic;
using System.Linq;
using ShopApi.Data;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public class PurchaseInvoiceTypeRepository : IPurchaseInvoiceTypeRepository
    {
        private ShopContext _context;

        public PurchaseInvoiceTypeRepository(ShopContext context)
        {
            this._context = context;
        }

        public bool CheckExisting(string code, string name)
        {
            return this._context.PurchaseInvoiceTypes.Any(x => x.Name == name && x.Code != code);
        }

        public IEnumerable<PurchaseInvoiceType> GetAll(string keyword, int page, int pageSize, out int totalRow)
        {
            totalRow = 0;
            IQueryable<PurchaseInvoiceType> query = null;
            if (!string.IsNullOrEmpty(keyword))
            {
                query = _context.PurchaseInvoiceTypes.Where(x => x.Code.Contains(keyword) ||
                    x.Name.Contains(keyword));
            }
            else
            {
                query = _context.PurchaseInvoiceTypes;
            }

            totalRow = query.Count();
            query = query.OrderBy(x => x.Name)
                        .Skip(page * pageSize)
                        .Take(pageSize);

            return query.ToList();
        }

        public IEnumerable<PurchaseInvoiceType> GetAllWithoutPaging()
        {
            return this._context.PurchaseInvoiceTypes.OrderBy(x => x.Name).ToList();
        }

        public PurchaseInvoiceType GetByCode(string code)
        {
            return this._context.PurchaseInvoiceTypes.Find(code);
        }

        public bool Insert(PurchaseInvoiceType purchaseInvoiceType)
        {
            try
            {
                this._context.PurchaseInvoiceTypes.Add(purchaseInvoiceType);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(PurchaseInvoiceType purchaseInvoiceType)
        {
            try
            {
                this._context.PurchaseInvoiceTypes.Update(purchaseInvoiceType);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Remove(PurchaseInvoiceType purchaseInvoiceType)
        {
            try
            {
                this._context.PurchaseInvoiceTypes.Remove(purchaseInvoiceType);
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
                var purchaseInvoiceType = this._context.PurchaseInvoiceTypes.Find(code);
                if (purchaseInvoiceType == null)
                {
                    return false;
                }

                this._context.PurchaseInvoiceTypes.Remove(purchaseInvoiceType);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}