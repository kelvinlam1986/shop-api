using ShopApi.Data;
using ShopApi.Models;

namespace ShopApi.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private ShopContext _context;

        public ReportRepository(ShopContext context)
        {
            this._context = context;
        }

        public Report GetReportByName(string name)
        {
            return this._context.Reports.Find(name);
        }
    }
}