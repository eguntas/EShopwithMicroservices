namespace EShop.Category.Services.StatisticServices
{
    public interface IStatisticService
    {
        Task<long> GetCategoryCount();
        Task<long> GetProductCount();
        Task<long> GetBrandCount();
        Task<decimal> GetProductAvgPrice();
        Task<decimal> GetProductMaxPrice();
        Task<decimal> GetProductMinPrice();
    }
}
