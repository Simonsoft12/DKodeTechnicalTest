using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using MyAPI.Entities;
using MyAPI.Entities.DTOs.Price;
using MyAPI.Repositories.Price;
using System.Globalization;

namespace MyAPI.Services.PriceService
{
    public class PriceService : IPriceService
    {
        private readonly IPriceRepository _priceRepository;
        private readonly IMapper _mapper;

        public PriceService(IPriceRepository priceRepository, IMapper mapper)
        {
            _priceRepository = priceRepository;
            _mapper = mapper;
        }

        public async Task<bool> ProcessPriceFileAsync(string filePath)
        {
            try
            {
                // 1. Read the CSV file and get the price data
                var prices = ReadPriceCsv(filePath);

                // 2. Map PriceDto to Price entities
                var priceEntities = _mapper.Map<List<Price>>(prices);

                // 3. Insert or update prices in the database
                await _priceRepository.InsertOrUpdatePricesAsync(priceEntities);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error processing price file", ex);
            }
        }

        private List<PriceDto> ReadPriceCsv(string filePath)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                Delimiter = ",",
                BadDataFound = null,
                MissingFieldFound = null,
                HeaderValidated = null
            };

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                return csv.GetRecords<PriceDto>().ToList();
            }
        }

    }
}
