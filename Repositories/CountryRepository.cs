using System;
using System.Collections.Generic;
using System.Linq;
using ShopApi.Data;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public class CountryRepository
    {
        private ShopContext _context;

        public CountryRepository(ShopContext context)
        {
            this._context = context;
        }

        public bool CheckExisting(string code, string name)
        {
            return this._context.Countries.Any(x => x.Name == name && x.Code != code);
        }

        public IEnumerable<Country> GetAll(string keyword, int page, int pageSize, out int totalRow)
        {
            totalRow = 0;
            IQueryable<Country> query = null;
            if (!string.IsNullOrEmpty(keyword))
            {
                query = _context.Countries.Where(x => x.Name.Contains(keyword));
            }
            else
            {
                query = _context.Countries;
            }

            totalRow = query.Count();
            query = query.OrderByDescending(x => x.CreatedDate)
                        .Skip(page * pageSize)
                        .Take(pageSize);

            return query.ToList();
        }

        public IEnumerable<Country> GetAllWithoutPaging()
        {
            return this._context.Countries.ToList();
        }

        public Country GetByCode(string code)
        {
            return this._context.Countries.Find(code);
        }

        public bool Insert(Country country)
        {
            try
            {
                this._context.Countries.Add(country);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Country country)
        {
            try
            {
                this._context.Countries.Update(country);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Remove(Country country)
        {
            try
            {
                this._context.Countries.Remove(country);
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
                var country = this._context.Countries.Find(code);
                if (country == null)
                {
                    return false;
                }

                this._context.Countries.Remove(country);
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