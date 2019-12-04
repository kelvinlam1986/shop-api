using System;
using System.Collections.Generic;
using System.Linq;
using ShopApi.Data;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public class StockRepository : IStockRepository
    {
        private ShopContext _context;

        public StockRepository(ShopContext context)
        {
            this._context = context;
        }

        public bool CheckExisting(string code, string name)
        {
            return this._context.Stocks.Any(x => x.Name == name && x.Code != code);
        }

        public IEnumerable<Stock> GetAll(string keyword, int page, int pageSize, out int totalRow)
        {
            totalRow = 0;
            IQueryable<Stock> query = null;
            if (!string.IsNullOrEmpty(keyword))
            {
                query = _context.Stocks.Where(
                    x => x.Code.Contains(keyword) ||
                    x.Name.Contains(keyword) ||
                    x.Address.Contains(keyword));
            }
            else
            {
                query = _context.Stocks;
            }

            totalRow = query.Count();
            query = query.OrderBy(x => x.Name)
                        .Skip(page * pageSize)
                        .Take(pageSize);

            return query.ToList();
        }

        public IEnumerable<Stock> GetAllWithoutPaging()
        {
            return this._context.Stocks.OrderBy(x => x.Name).ToList();
        }

        public Stock GetByCode(string code)
        {
            return this._context.Stocks.Find(code);
        }

        public bool Insert(Stock stock)
        {
            try
            {
                this._context.Stocks.Add(stock);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Stock stock)
        {
            try
            {
                this._context.Stocks.Update(stock);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Remove(Stock stock)
        {
            try
            {
                this._context.Stocks.Remove(stock);
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
                var stock = this._context.Stocks.Find(code);
                if (stock == null)
                {
                    return false;
                }

                this._context.Stocks.Remove(stock);
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