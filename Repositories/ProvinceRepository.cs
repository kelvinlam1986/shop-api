using System;
using System.Collections.Generic;
using System.Linq;
using ShopApi.Data;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public class ProvinceRepository : IProvinceRepository
    {
        private ShopContext _context;

        public ProvinceRepository(ShopContext context)
        {
            this._context = context;
        }

        public bool CheckExisting(string code, string name)
        {
            return this._context.Provinces.Any(x => x.Name == name && x.Code != code);
        }

        public IEnumerable<Province> GetAll(string keyword, int page, int pageSize, out int totalRow)
        {
            totalRow = 0;
            IQueryable<Province> query = null;
            if (!string.IsNullOrEmpty(keyword))
            {
                query = _context.Provinces.Where(
                    x => x.Code.Contains(keyword) ||
                    x.Name.Contains(keyword));
            }
            else
            {
                query = _context.Provinces;
            }

            totalRow = query.Count();
            query = query.OrderBy(x => x.Name)
                        .Skip(page * pageSize)
                        .Take(pageSize);

            return query.ToList();
        }

        public IEnumerable<Province> GetAllByCountryCode(string countryCode, string keyword, int page, int pageSize, out int totalRow)
        {
            totalRow = 0;
            IQueryable<Province> query = null;
            if (!string.IsNullOrEmpty(countryCode))
            {
                query = this._context.Provinces.Where(x => x.CountryCode == countryCode);
            }
            else
            {
                query = this._context.Provinces;
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(
                    x => x.Code.Contains(keyword) ||
                    x.Name.Contains(keyword));
            }

            totalRow = query.Count();
            query = query.OrderBy(x => x.Name)
                        .Skip(page * pageSize)
                        .Take(pageSize);

            return query.ToList();
        }

        public IEnumerable<Province> GetAllWithoutPaging()
        {
            return this._context.Provinces.OrderBy(x => x.Name).ToList();
        }

        public Province GetByCode(string code)
        {
            return this._context.Provinces.Find(code);
        }

        public bool Insert(Province province)
        {
            try
            {
                this._context.Provinces.Add(province);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Province province)
        {
            try
            {
                this._context.Provinces.Update(province);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Remove(Province province)
        {
            try
            {
                this._context.Provinces.Remove(province);
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
                var province = this._context.Provinces.Find(code);
                if (province == null)
                {
                    return false;
                }

                this._context.Provinces.Remove(province);
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