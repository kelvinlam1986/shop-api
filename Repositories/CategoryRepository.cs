using System;
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

        public Category GetById(int id)
        {
            return this._context.Categories.Find(id);
        }

        public bool Update(Category category)
        {
            try
            {
                this._context.Categories.Update(category);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool Insert(Category category)
        {
            try
            {
                this._context.Categories.Add(category);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CheckExistingCategory(int id, string name)
        {
            return this._context.Categories.Any(x => x.Name == name && x.Id != id);
        }
    }
}