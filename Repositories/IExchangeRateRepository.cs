namespace ShopApi.Repositories
{
    public interface IExchangeRateRepository
    {
        decimal GetLatestExchangeRate(string currencyCode);
    }
}