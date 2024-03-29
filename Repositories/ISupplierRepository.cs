using System.Collections.Generic;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public interface ISupplierRepository
    {
        IEnumerable<Supplier> GetAllWithoutPaging();
        IEnumerable<Supplier> GetAll(string keyword, int page, int pageSize, out int totalRow);
        Supplier GetById(int id);
        bool CheckExistingSupplier(int id, string name);
        bool Update(Supplier supplier);
        bool Insert(Supplier supplier);
    }
}