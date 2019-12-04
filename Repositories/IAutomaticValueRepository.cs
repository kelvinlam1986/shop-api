using ShopApi.Models;

namespace ShopApi.Repositories
{
    public interface IAutomaticValueRepository
    {
        AutomaticValue GetAutoId(string tableName);
        bool UpdateLastAutoId(string tableName, string lastAutoId);
    }
}