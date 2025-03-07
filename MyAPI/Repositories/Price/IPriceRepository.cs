namespace MyAPI.Repositories.Price
{
    public interface IPriceRepository
    {
        Task InsertOrUpdatePricesAsync(List<Entities.Price> prices);
    }
}
