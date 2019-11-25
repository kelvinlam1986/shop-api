using System.Collections.Generic;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public interface ISupplierRepository
    {
        IEnumerable<Supplier> GetAllWithoutPaging(int branchId);
        IEnumerable<Supplier> GetAll(int branchId, string keyword, int page, int pageSize, out int totalRow);
    }
}