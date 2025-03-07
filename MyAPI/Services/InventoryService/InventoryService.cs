using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using MyAPI.Entities;
using MyAPI.Entities.DTOs.Inventory;
using MyAPI.Repositories.Inventory;
using System.Globalization;

namespace MyAPI.Services.InventoryService
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IMapper _mapper;

        public InventoryService(IInventoryRepository inventoryRepository, IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }

        public async Task<bool> ProcessInventoryFileAsync(string filePath)
        {
            try
            {
                // 1. Read the CSV file and get the inventory data
                var inventoryItems = ReadInventoryCsv(filePath);

                // 2. Filter inventory items that are dispatched within 24 hours
                var filteredItems = inventoryItems.Where(item => Data.Helpers.StringHelper.IsDispatchedWithin24Hours(item.Shipping)).ToList();

                // 3. Map InventoryDto to Inventory entities
                var inventoryEntities = _mapper.Map<List<Inventory>>(filteredItems);

                // 4. Insert or update inventory in the database
                await _inventoryRepository.InsertOrUpdateInventoryAsync(inventoryEntities);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error processing inventory file", ex);
            }
        }

        private List<InventoryDto> ReadInventoryCsv(string filePath)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                Delimiter = ",",
                BadDataFound = null,
                MissingFieldFound = null,
                HeaderValidated = null
            };

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                return csv.GetRecords<InventoryDto>().ToList();
            }
        }
    }
}
