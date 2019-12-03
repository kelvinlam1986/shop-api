using System.Collections.Generic;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public interface IExportTypeRepository
    {
        IEnumerable<ExportType> GetAll(string keyword, int page, int pageSize, out int totalRow);
        ExportType GetByCode(string code);
        bool Update(ExportType exportType);
        bool Insert(ExportType exportType);
        bool Remove(ExportType exportType);
        bool RemoveByCode(string code);
        bool CheckExisting(string code, string name);
        IEnumerable<ExportType> GetAllWithoutPaging();
    }
}