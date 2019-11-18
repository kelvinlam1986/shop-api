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
    }
}