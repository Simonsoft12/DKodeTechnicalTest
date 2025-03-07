
namespace MyAPI.Services.PriceService
{
    public interface IPriceService
    {
        Task<bool> ProcessPriceFileAsync(string filePath);
    }
}
