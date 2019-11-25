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

        public IEnumerable<Supplier> GetAll(int branchId, string keyword, int page, int pageSize, out int totalRow)
        {
            totalRow = 0;
            IQueryable<Supplier> query = null;
            query = this._context.Suppliers.Where(x => x.BranchId == branchId);
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Name.Contains(keyword)
                            || x.Address.Contains(keyword)
                            || x.Contact.Contains(keyword));
            }

            totalRow = query.Count();
            query = query.OrderByDescending(x => x.CreatedDate)
                        .Skip(page * pageSize)
                        .Take(pageSize);

            return query.ToList();
        }
    }
}