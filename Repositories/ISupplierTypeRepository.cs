using System.Collections.Generic;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public interface ISupplierTypeRepository
    {
        IEnumerable<SupplierType> GetAll(string keyword, int page, int pageSize, out int totalRow);
        SupplierType GetByCode(string code);
        bool Update(SupplierType stock);
        bool Insert(SupplierType stock);
        bool Remove(SupplierType stock);
        bool RemoveByCode(string code);
        bool CheckExisting(string code, string name);
        IEnumerable<SupplierType> GetAllWithoutPaging();
    }
}