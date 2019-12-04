using System.Linq;
using ShopApi.Data;

namespace ShopApi.Repositories
{
    public class ExchangeRateRepository : IExchangeRateRepository
    {
        private ShopContext _context;

        public ExchangeRateRepository(ShopContext context)
        {
            this._context = context;
        }

        public decimal GetLatestExchangeRate(string currencyCode)
        {
            return this._context.ExchangeRates.Where(x => x.Discontinued && x.CurrencyCode == currencyCode)
                .OrderByDescending(x => x.DateOfRate).FirstOrDefault().Rate;
        }
    }
}