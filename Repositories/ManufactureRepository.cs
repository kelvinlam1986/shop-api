using System;
using System.Collections.Generic;
using System.Linq;
using ShopApi.Data;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public class ManufactureRepository : IManufactureRepository
    {
        private ShopContext _context;

        public ManufactureRepository(ShopContext context)
        {
            this._context = context;
        }

        public bool CheckExisting(string code, string name)
        {
            return this._context.Manufactures.Any(x => x.Name == name && x.Code != code);
        }

        public IEnumerable<Manufacture> GetAll(string keyword, int page, int pageSize, out int totalRow)
        {
            totalRow = 0;
            IQueryable<Manufacture> query = null;
            if (!string.IsNullOrEmpty(keyword))
            {
                query = _context.Manufactures.Where(
                    x => x.Code.Contains(keyword) ||
                    x.Name.Contains(keyword) ||
                    x.Address.Contains(keyword));
            }
            else
            {
                query = _context.Manufactures;
            }

            totalRow = query.Count();
            query = query.OrderBy(x => x.Name)
                        .Skip(page * pageSize)
                        .Take(pageSize);

            return query.ToList();
        }

        public IEnumerable<Manufacture> GetByRangeAndCondition(
           DateTime startDate, DateTime endDate, string countryId, string username,
           string keyword, int page, int pageSize, out int totalRow)
        {
            totalRow = 0;
            IQueryable<Manufacture> query = null;
            query = this._context.Manufactures.Where(x => x.DueDate >= startDate && x.DueDate <= endDate);
            if (!string.IsNullOrEmpty(countryId))
            {
                query = query.Where(x => x.CountryId == countryId);
            }

            if (!string.IsNullOrEmpty(username))
            {
                query = query.Where(x => x.CreatedBy == username);
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(
                    x => x.Code.Contains(keyword) ||
                    x.Name.Contains(keyword) ||
                    x.Address.Contains(keyword));
            }

            totalRow = query.Count();
            query = query.OrderBy(x => x.Name)
                        .Skip(page * pageSize)
                        .Take(pageSize);

            return query.ToList();
        }

        public IEnumerable<Manufacture> GetAllWithoutPaging()
        {
            return this._context.Manufactures.OrderBy(x => x.Name).ToList();
        }

        public Manufacture GetByCode(string code)
        {
            return this._context.Manufactures.Find(code);
        }

        public bool Insert(Manufacture manufacture)
        {
            try
            {
                this._context.Manufactures.Add(manufacture);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Manufacture manufacture)
        {
            try
            {
                this._context.Manufactures.Update(manufacture);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Remove(Manufacture manufacture)
        {
            try
            {
                this._context.Manufactures.Remove(manufacture);
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
                var manufacture = this._context.Manufactures.Find(code);
                if (manufacture == null)
                {
                    return false;
                }

                this._context.Manufactures.Remove(manufacture);
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