using System.Collections.Generic;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public interface IStockRepository
    {
        IEnumerable<Stock> GetAll(string keyword, int page, int pageSize, out int totalRow);
        Stock GetByCode(string code);
        bool Update(Stock stock);
        bool Insert(Stock stock);
        bool Remove(Stock stock);
        bool RemoveByCode(string code);
        bool CheckExisting(string code, string name);
        IEnumerable<Stock> GetAllWithoutPaging();
    }
}