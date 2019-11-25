using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ShopApi.Data;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private ShopContext _context;

        public ProductRepository(ShopContext context)
        {
            this._context = context;
        }

        public IEnumerable<Product> GetAll(int branchId, string keyword, int page, int pageSize, out int totalRow)
        {
            totalRow = 0;
            IQueryable<Product> query = null;
            query = this._context.Products
                .Include(x => x.Supplier)
                .Include(x => x.Category).Where(x => x.BranchId == branchId);
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Name.Contains(keyword)
                            || x.Description.Contains(keyword));
            }

            totalRow = query.Count();
            query = query.OrderByDescending(x => x.CreatedDate)
                        .Skip(page * pageSize)
                        .Take(pageSize);

            return query.ToList();
        }

        public Product GetById(int id)
        {
            return this._context.Products.Find(id);
        }

        public bool CheckExistingProduct(int id, string serial, string name)
        {
            bool isExisting = this._context.Products.Any(x => x.Serial == serial && x.Id != id);
            if (isExisting)
            {
                return isExisting;
            }
            else
            {
                isExisting = this._context.Products.Any(x => x.Name == name && x.Id != id);
            }

            return isExisting;
        }

        public bool Update(Product product)
        {
            try
            {
                this._context.Products.Update(product);
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