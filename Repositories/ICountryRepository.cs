using System.Collections.Generic;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetAll(string keyword, int page, int pageSize, out int totalRow);
        Country GetByCode(string code);
        bool Update(Country country);
        bool Insert(Country country);
        bool Remove(Country country);
        bool RemoveByCode(string code);
        bool CheckExistingName(string code, string name);
        IEnumerable<Country> GetAllWithoutPaging();
    }
}