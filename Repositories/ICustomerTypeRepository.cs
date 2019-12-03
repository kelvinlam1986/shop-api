using System.Collections.Generic;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public interface ICustomerTypeRepository
    {
        IEnumerable<CustomerType> GetAll(string keyword, int page, int pageSize, out int totalRow);
        CustomerType GetByCode(string code);
        bool Update(CustomerType bank);
        bool Insert(CustomerType bank);
        bool Remove(CustomerType bank);
        bool RemoveByCode(string code);
        bool CheckExisting(string code, string name);
        IEnumerable<CustomerType> GetAllWithoutPaging();
    }
}