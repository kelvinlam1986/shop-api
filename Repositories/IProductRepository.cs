using System.Collections.Generic;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll(int branchId, string keyword, int page, int pageSize, out int totalRow);
    }
}