using System;
using System.Collections.Generic;
using System.Linq;
using ShopApi.Data;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public class ExportTypeRepository : IExportTypeRepository
    {
        private ShopContext _context;

        public ExportTypeRepository(ShopContext context)
        {
            this._context = context;
        }

        public bool CheckExisting(string code, string name)
        {
            return this._context.ExportTypes.Any(x => x.Name == name && x.Code != code);
        }

        public IEnumerable<ExportType> GetAll(string keyword, int page, int pageSize, out int totalRow)
        {
            totalRow = 0;
            IQueryable<ExportType> query = null;
            if (!string.IsNullOrEmpty(keyword))
            {
                query = _context.ExportTypes.Where(x => x.Code.Contains(keyword) ||
                    x.Name.Contains(keyword));
            }
            else
            {
                query = _context.ExportTypes;
            }

            totalRow = query.Count();
            query = query.OrderBy(x => x.Name)
                        .Skip(page * pageSize)
                        .Take(pageSize);

            return query.ToList();
        }

        public IEnumerable<ExportType> GetAllWithoutPaging()
        {
            return this._context.ExportTypes.OrderBy(x => x.Name).ToList();
        }

        public ExportType GetByCode(string code)
        {
            return this._context.ExportTypes.Find(code);
        }

        public bool Insert(ExportType exportType)
        {
            try
            {
                this._context.ExportTypes.Add(exportType);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(ExportType exportType)
        {
            try
            {
                this._context.ExportTypes.Update(exportType);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Remove(ExportType exportType)
        {
            try
            {
                this._context.ExportTypes.Remove(exportType);
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
                var exportType = this._context.ExportTypes.Find(code);
                if (exportType == null)
                {
                    return false;
                }

                this._context.ExportTypes.Remove(exportType);
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