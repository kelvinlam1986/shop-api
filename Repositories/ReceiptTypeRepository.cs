using System;
using System.Collections.Generic;
using System.Linq;
using ShopApi.Data;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public class ReceiptTypeRepository : IReceiptTypeRepository
    {
        private ShopContext _context;

        public ReceiptTypeRepository(ShopContext context)
        {
            this._context = context;
        }

        public bool CheckExisting(string code, string name)
        {
            return this._context.ReceiptTypes.Any(x => x.Name == name && x.Code != code);
        }

        public IEnumerable<ReceiptType> GetAll(string keyword, int page, int pageSize, out int totalRow)
        {
            totalRow = 0;
            IQueryable<ReceiptType> query = null;
            if (!string.IsNullOrEmpty(keyword))
            {
                query = _context.ReceiptTypes.Where(x => x.Code.Contains(keyword) ||
                    x.Name.Contains(keyword));
            }
            else
            {
                query = _context.ReceiptTypes;
            }

            totalRow = query.Count();
            query = query.OrderBy(x => x.Name)
                        .Skip(page * pageSize)
                        .Take(pageSize);

            return query.ToList();
        }

        public IEnumerable<ReceiptType> GetAllWithoutPaging()
        {
            return this._context.ReceiptTypes.OrderBy(x => x.Name).ToList();
        }

        public ReceiptType GetByCode(string code)
        {
            return this._context.ReceiptTypes.Find(code);
        }

        public bool Insert(ReceiptType receiptType)
        {
            try
            {
                this._context.ReceiptTypes.Add(receiptType);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(ReceiptType receiptType)
        {
            try
            {
                this._context.ReceiptTypes.Update(receiptType);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Remove(ReceiptType receiptType)
        {
            try
            {
                this._context.ReceiptTypes.Remove(receiptType);
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
                var receiptType = this._context.ReceiptTypes.Find(code);
                if (receiptType == null)
                {
                    return false;
                }

                this._context.ReceiptTypes.Remove(receiptType);
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