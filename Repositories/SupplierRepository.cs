using System.Collections.Generic;
using System.Linq;
using ShopApi.Data;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private ShopContext _context;

        public SupplierRepository(ShopContext context)
        {
            this._context = context;
        }

        public IEnumerable<Supplier> GetAllWithoutPaging(int branchId)
        {
            return this._context.Suppliers.Where(x => x.BranchId == branchId).ToList();
        }
    }
}