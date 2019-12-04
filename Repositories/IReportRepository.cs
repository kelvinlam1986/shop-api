using ShopApi.Models;

namespace ShopApi.Repositories
{
    public interface IReportRepository
    {
        Report GetReportByName(string name);
    }
}