using System.Collections.Generic;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public interface IImportTypeRepository
    {
        IEnumerable<ImportType> GetAll(string keyword, int page, int pageSize, out int totalRow);
        ImportType GetByCode(string code);
        bool Update(ImportType importType);
        bool Insert(ImportType importType);
        bool Remove(ImportType importType);
        bool RemoveByCode(string code);
        bool CheckExisting(string code, string name);
        IEnumerable<ImportType> GetAllWithoutPaging();
    }
}