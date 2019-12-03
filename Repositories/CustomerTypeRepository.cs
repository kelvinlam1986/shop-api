using System;
using System.Collections.Generic;
using System.Linq;
using ShopApi.Data;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public class CustomerTypeRepository : ICustomerTypeRepository
    {
        private ShopContext _context;

        public CustomerTypeRepository(ShopContext context)
        {
            this._context = context;
        }

        public bool CheckExisting(string code, string name)
        {
            return this._context.Countries.Any(x => x.Name == name && x.Code != code);
        }

        public IEnumerable<CustomerType> GetAll(string keyword, int page, int pageSize, out int totalRow)
        {
            totalRow = 0;
            IQueryable<CustomerType> query = null;
            if (!string.IsNullOrEmpty(keyword))
            {
                query = _context.CustomerTypes.Where(
                    x => x.Code.Contains(keyword) ||
                    x.Name.Contains(keyword));
            }
            else
            {
                query = _context.CustomerTypes;
            }

            totalRow = query.Count();
            query = query.OrderBy(x => x.Name)
                        .Skip(page * pageSize)
                        .Take(pageSize);

            return query.ToList();
        }

        public IEnumerable<CustomerType> GetAllWithoutPaging()
        {
            return this._context.CustomerTypes.OrderBy(x => x.Name).ToList();
        }

        public CustomerType GetByCode(string code)
        {
            return this._context.CustomerTypes.Find(code);
        }

        public bool Insert(CustomerType customerType)
        {
            try
            {
                this._context.CustomerTypes.Add(customerType);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(CustomerType customerType)
        {
            try
            {
                this._context.CustomerTypes.Update(customerType);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Remove(CustomerType customerType)
        {
            try
            {
                this._context.CustomerTypes.Remove(customerType);
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
                var customerType = this._context.CustomerTypes.Find(code);
                if (customerType == null)
                {
                    return false;
                }

                this._context.CustomerTypes.Remove(customerType);
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