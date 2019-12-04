using System;
using System.Collections.Generic;
using System.Linq;
using ShopApi.Data;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public class SupplierTypeRepository : ISupplierTypeRepository
    {
        private ShopContext _context;

        public SupplierTypeRepository(ShopContext context)
        {
            this._context = context;
        }

        public bool CheckExisting(string code, string name)
        {
            return this._context.SupplierTypes.Any(x => x.Name == name && x.Code != code);
        }

        public IEnumerable<SupplierType> GetAll(string keyword, int page, int pageSize, out int totalRow)
        {
            totalRow = 0;
            IQueryable<SupplierType> query = null;
            if (!string.IsNullOrEmpty(keyword))
            {
                query = _context.SupplierTypes.Where(
                    x => x.Code.Contains(keyword) ||
                    x.Name.Contains(keyword));
            }
            else
            {
                query = _context.SupplierTypes;
            }

            totalRow = query.Count();
            query = query.OrderBy(x => x.Name)
                        .Skip(page * pageSize)
                        .Take(pageSize);

            return query.ToList();
        }

        public IEnumerable<SupplierType> GetAllWithoutPaging()
        {
            return this._context.SupplierTypes.OrderBy(x => x.Name).ToList();
        }

        public SupplierType GetByCode(string code)
        {
            return this._context.SupplierTypes.Find(code);
        }

        public bool Insert(SupplierType supplierType)
        {
            try
            {
                this._context.SupplierTypes.Add(supplierType);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(SupplierType supplierType)
        {
            try
            {
                this._context.SupplierTypes.Update(supplierType);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Remove(SupplierType supplierType)
        {
            try
            {
                this._context.SupplierTypes.Remove(supplierType);
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
                var supplierType = this._context.SupplierTypes.Find(code);
                if (supplierType == null)
                {
                    return false;
                }

                this._context.SupplierTypes.Remove(supplierType);
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