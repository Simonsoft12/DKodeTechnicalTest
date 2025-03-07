
namespace MyAPI.Services.InventoryService
{
    public interface IInventoryService
    {
        Task<bool> ProcessInventoryFileAsync(string filePath);
    }
}
