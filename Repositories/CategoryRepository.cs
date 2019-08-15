using System.Collections.Generic;
using System.Linq;
using ShopApi.Data;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private ShopContext _context;

        public CategoryRepository(ShopContext context)
        {
            this._context = context;
        }

        public IEnumerable<Category> GetAll(string keyword, int page, int pageSize, out int totalRow)
        {
            totalRow = 0;
            IQueryable<Category> query = null;
            if (!string.IsNullOrEmpty(keyword))
            {
                query = _context.Categories.Where(x => x.Name.Contains(keyword));
            }
            else
            {
                query = _context.Categories;
            }

            totalRow = query.Count();
            query = query.OrderByDescending(x => x.CreatedDate)
                        .Skip(page * pageSize)
                        .Take(pageSize);

            return query.ToList();
        }
    }
}