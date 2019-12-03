using System;
using System.Collections.Generic;
using System.Linq;
using ShopApi.Data;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public class ImportTypeRepository : IImportTypeRepository
    {
        private ShopContext _context;

        public ImportTypeRepository(ShopContext context)
        {
            this._context = context;
        }

        public bool CheckExisting(string code, string name)
        {
            return this._context.ImportTypes.Any(x => x.Name == name && x.Code != code);
        }

        public IEnumerable<ImportType> GetAll(string keyword, int page, int pageSize, out int totalRow)
        {
            totalRow = 0;
            IQueryable<ImportType> query = null;
            if (!string.IsNullOrEmpty(keyword))
            {
                query = _context.ImportTypes.Where(x => x.Code.Contains(keyword) ||
                    x.Name.Contains(keyword));
            }
            else
            {
                query = _context.ImportTypes;
            }

            totalRow = query.Count();
            query = query.OrderBy(x => x.Name)
                        .Skip(page * pageSize)
                        .Take(pageSize);

            return query.ToList();
        }

        public IEnumerable<ImportType> GetAllWithoutPaging()
        {
            return this._context.ImportTypes.OrderBy(x => x.Name).ToList();
        }

        public ImportType GetByCode(string code)
        {
            return this._context.ImportTypes.Find(code);
        }

        public bool Insert(ImportType importType)
        {
            try
            {
                this._context.ImportTypes.Add(importType);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(ImportType importType)
        {
            try
            {
                this._context.ImportTypes.Update(importType);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Remove(ImportType importType)
        {
            try
            {
                this._context.ImportTypes.Remove(importType);
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
                var importType = this._context.ImportTypes.Find(code);
                if (importType == null)
                {
                    return false;
                }

                this._context.ImportTypes.Remove(importType);
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