using System;
using System.Collections.Generic;
using System.Linq;
using ShopApi.Data;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public class SalesInvoiceTypeRepository : ISalesInvoiceTypeRepository
    {
        private ShopContext _context;

        public SalesInvoiceTypeRepository(ShopContext context)
        {
            this._context = context;
        }

        public bool CheckExisting(string code, string name)
        {
            return this._context.SalesInvoiceTypes.Any(x => x.Name == name && x.Code != code);
        }

        public IEnumerable<SalesInvoiceType> GetAll(string keyword, int page, int pageSize, out int totalRow)
        {
            totalRow = 0;
            IQueryable<SalesInvoiceType> query = null;
            if (!string.IsNullOrEmpty(keyword))
            {
                query = _context.SalesInvoiceTypes.Where(x => x.Code.Contains(keyword) ||
                    x.Name.Contains(keyword));
            }
            else
            {
                query = _context.SalesInvoiceTypes;
            }

            totalRow = query.Count();
            query = query.OrderBy(x => x.Name)
                        .Skip(page * pageSize)
                        .Take(pageSize);

            return query.ToList();
        }

        public IEnumerable<SalesInvoiceType> GetAllWithoutPaging()
        {
            return this._context.SalesInvoiceTypes.OrderBy(x => x.Name).ToList();
        }

        public SalesInvoiceType GetByCode(string code)
        {
            return this._context.SalesInvoiceTypes.Find(code);
        }

        public bool Insert(SalesInvoiceType salesInvoiceType)
        {
            try
            {
                this._context.SalesInvoiceTypes.Add(salesInvoiceType);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(SalesInvoiceType salesInvoiceType)
        {
            try
            {
                this._context.SalesInvoiceTypes.Update(salesInvoiceType);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Remove(SalesInvoiceType salesInvoiceType)
        {
            try
            {
                this._context.SalesInvoiceTypes.Remove(salesInvoiceType);
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
                var salesInvoiceType = this._context.SalesInvoiceTypes.Find(code);
                if (salesInvoiceType == null)
                {
                    return false;
                }

                this._context.SalesInvoiceTypes.Remove(salesInvoiceType);
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