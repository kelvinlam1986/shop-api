using System;
using System.Collections.Generic;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public interface IManufactureRepository
    {
        IEnumerable<Manufacture> GetAll(string keyword, int page, int pageSize, out int totalRow);
        IEnumerable<Manufacture> GetByRangeAndCondition(
            DateTime startDate, DateTime endDate, string countryId,
            string username, string keyword, int page, int pageSize, out int totalRow);
        Manufacture GetByCode(string code);
        bool Update(Manufacture manufacture);
        bool Insert(Manufacture manufacture);
        bool Remove(Manufacture manufacture);
        bool RemoveByCode(string code);
        bool CheckExisting(string code, string name);
        IEnumerable<Manufacture> GetAllWithoutPaging();
    }
}