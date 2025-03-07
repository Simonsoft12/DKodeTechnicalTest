using AutoMapper;
using MyAPI.Entities;
using MyAPI.Entities.DTOs.Product;
using MyAPI.Repositories.Product;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace MyAPI.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<bool> ProcessProductFileAsync(string filePath)
        {
            try
            {
                // 1. Read the CSV file and get the filtered product data
                var products = ReadProductCsv(filePath);

                // 2. Map ProductDto to Product entities
                var productEntities = _mapper.Map<List<Product>>(products);

                // 3. Insert or update products in the database
                await _productRepository.InsertOrUpdateProductsAsync(productEntities);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error processing product file", ex);
            }
        }

        private List<ProductDto> ReadProductCsv(string filePath)
        {
            var products = new List<ProductDto>();
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                Delimiter = ";",
                BadDataFound = null,
                MissingFieldFound = null
            };

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                return csv.GetRecords<ProductDto>()
                        .Where(record => record.IsWire.HasValue && record.IsWire.Value == false &&
                                         Data.Helpers.StringHelper.IsDispatchedWithin24Hours(record.Shipping))
                        .ToList();
            }
        }

    }
}
