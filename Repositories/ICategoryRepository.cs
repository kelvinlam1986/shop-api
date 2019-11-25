using System.Collections.Generic;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll(string keyword, int page, int pageSize, out int totalRow);
        Category GetById(int id);
        bool Update(Category category);
        bool Insert(Category category);
        bool CheckExistingCategory(int id, string name);
        IEnumerable<Category> GetAllWithoutPaging();
    }
}