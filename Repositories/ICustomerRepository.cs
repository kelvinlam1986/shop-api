using System.Collections.Generic;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll(string keyword, int page, int pageSize, out int totalRow);
    }
}