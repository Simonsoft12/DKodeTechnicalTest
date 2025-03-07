namespace MyAPI.Repositories.Inventory
{
    public interface IInventoryRepository
    {
        Task InsertOrUpdateInventoryAsync(List<Entities.Inventory> inventoryItems);
    }
}
