namespace MyAPI.Repositories.Product
{
    public interface IProductRepository
    {
        Task InsertOrUpdateProductsAsync(List<Entities.Product> products);
    }
}
