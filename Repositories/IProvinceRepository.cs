using System.Collections.Generic;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public interface IProvinceRepository
    {
        IEnumerable<Province> GetAll(string keyword, int page, int pageSize, out int totalRow);
        IEnumerable<Province> GetAllByCountryCode(string countryCode, string keyword, int page, int pageSize, out int totalRow);
        Province GetByCode(string code);
        bool Update(Province province);
        bool Insert(Province province);
        bool Remove(Province province);
        bool RemoveByCode(string code);
        bool CheckExisting(string code, string name);
        IEnumerable<Province> GetAllWithoutPaging();
    }
}