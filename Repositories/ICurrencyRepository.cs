using System.Collections.Generic;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public interface ICurrencyRepository
    {
        IEnumerable<Currency> GetAll(string keyword, int page, int pageSize, out int totalRow);
        Currency GetByCode(string code);
        bool Update(Currency bank);
        bool Insert(Currency bank);
        bool Remove(Currency bank);
        bool RemoveByCode(string code);
        bool CheckExisting(string code, string name);
        IEnumerable<Currency> GetAllWithoutPaging();
    }
}