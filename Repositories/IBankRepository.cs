using System.Collections.Generic;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public interface IBankRepository
    {
        IEnumerable<Bank> GetAll(string keyword, int page, int pageSize, out int totalRow);
        Bank GetByCode(string code);
        bool Update(Bank bank);
        bool Insert(Bank bank);
        bool Remove(Bank bank);
        bool RemoveByCode(string code);
        bool CheckExisting(string code, string name);
        IEnumerable<Bank> GetAllWithoutPaging();
    }
}