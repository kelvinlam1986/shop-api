using System;
using System.Collections.Generic;
using System.Linq;
using ShopApi.Data;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public class BankRepository : IBankRepository
    {
        private ShopContext _context;

        public BankRepository(ShopContext context)
        {
            this._context = context;
        }

        public bool CheckExisting(string code, string name)
        {
            return this._context.Banks.Any(x => x.Name == name && x.Code != code);
        }

        public IEnumerable<Bank> GetAll(string keyword, int page, int pageSize, out int totalRow)
        {
            totalRow = 0;
            IQueryable<Bank> query = null;
            if (!string.IsNullOrEmpty(keyword))
            {
                query = _context.Banks.Where(x => x.Name.Contains(keyword) ||
                    x.Address.Contains(keyword));
            }
            else
            {
                query = _context.Banks;
            }

            totalRow = query.Count();
            query = query.OrderByDescending(x => x.CreatedDate)
                        .Skip(page * pageSize)
                        .Take(pageSize);

            return query.ToList();
        }

        public IEnumerable<Bank> GetAllWithoutPaging()
        {
            return this._context.Banks.ToList();
        }

        public Bank GetByCode(string code)
        {
            return this._context.Banks.Find(code);
        }

        public bool Insert(Bank bank)
        {
            try
            {
                this._context.Banks.Add(bank);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Bank bank)
        {
            try
            {
                this._context.Banks.Update(bank);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Remove(Bank bank)
        {
            try
            {
                this._context.Banks.Remove(bank);
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
                var bank = this._context.Banks.Find(code);
                if (bank == null)
                {
                    return false;
                }

                this._context.Banks.Remove(bank);
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