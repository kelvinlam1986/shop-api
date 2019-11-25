using System.Collections.Generic;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public interface ISupplierRepository
    {
        IEnumerable<Supplier> GetAllWithoutPaging(int branchId);
    }
}