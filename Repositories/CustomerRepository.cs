using System.Collections.Generic;
using System.Linq;
using ShopApi.Data;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private ShopContext _context;

        public CustomerRepository(ShopContext context)
        {
            this._context = context;
        }

        public IEnumerable<Customer> GetAll(int branchId, string keyword, int page, int pageSize, out int totalRow)
        {
            totalRow = 0;
            IQueryable<Customer> query = null;
            query = this._context.Customers.Where(x => x.BranchId == branchId);
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.FirstName.Contains(keyword)
                            || x.LastName.Contains(keyword)
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