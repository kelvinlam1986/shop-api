using System.Collections.Generic;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll(string keyword, int page, int pageSize, out int totalRow);
    }
}