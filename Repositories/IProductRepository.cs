using System.Collections.Generic;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll(int branchId, string keyword, int page, int pageSize, out int totalRow);
        Product GetById(int id);
        bool CheckExistingProduct(int id, string serial, string name);
        bool Update(Product product);
    }
}