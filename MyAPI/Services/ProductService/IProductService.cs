
namespace MyAPI.Services.ProductService
{
    public interface IProductService
    {
        Task<bool> ProcessProductFileAsync(string filePath);
    }
}
