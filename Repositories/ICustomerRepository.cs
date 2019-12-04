using System.Collections.Generic;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll(string keyword, int page, int pageSize, out int totalRow);
        Customer GetById(int id);
        bool Update(Customer customer);
        bool Insert(Customer customer);
        bool CheckExistingCustomer(int id, string firstName, string lastName);
    }
}