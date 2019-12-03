using System;
using System.Collections.Generic;
using System.Linq;
using ShopApi.Data;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private ShopContext _context;

        public CurrencyRepository(ShopContext context)
        {
            this._context = context;
        }

        public bool CheckExisting(string code, string name)
        {
            return this._context.Currencies.Any(x => x.Name == name && x.Code != code);
        }

        public IEnumerable<Currency> GetAll(string keyword, int page, int pageSize, out int totalRow)
        {
            totalRow = 0;
            IQueryable<Currency> query = null;
            if (!string.IsNullOrEmpty(keyword))
            {
                query = _context.Currencies.Where(
                    x => x.Code.Contains(keyword) ||
                    x.Name.Contains(keyword));
            }
            else
            {
                query = _context.Currencies;
            }

            totalRow = query.Count();
            query = query.OrderByDescending(x => x.CreatedDate)
                        .Skip(page * pageSize)
                        .Take(pageSize);

            return query.ToList();
        }

        public IEnumerable<Currency> GetAllWithoutPaging()
        {
            return this._context.Currencies.ToList();
        }

        public Currency GetByCode(string code)
        {
            return this._context.Currencies.Find(code);
        }

        public bool Insert(Currency currency)
        {
            try
            {
                this._context.Currencies.Add(currency);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Currency currency)
        {
            try
            {
                this._context.Currencies.Update(currency);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Remove(Currency currency)
        {
            try
            {
                this._context.Currencies.Remove(currency);
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
                var currency = this._context.Currencies.Find(code);
                if (currency == null)
                {
                    return false;
                }

                this._context.Currencies.Remove(currency);
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