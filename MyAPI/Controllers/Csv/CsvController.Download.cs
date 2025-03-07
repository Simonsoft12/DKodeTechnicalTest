using Microsoft.AspNetCore.Mvc;

namespace MyAPI.Controllers.Csv
{
    public partial class CsvController
    {
        [HttpGet("download-and-save")]
        public async Task<IActionResult> DownloadAndSaveData()
        {
            try
            {
                // Step 1: Download Products.csv and Save data to DB
                var productFilePath = await _fileDownloadService.DownloadCsvAsync("https://rekturacjazadanie.blob.core.windows.net/zadanie/Products.csv", "Products.csv");
                var products = await _productService.ProcessProductFileAsync(productFilePath);

                // Step 2: Download Inventory.csv and Save data to DB
                var inventoryFilePath = await _fileDownloadService.DownloadCsvAsync("https://rekturacjazadanie.blob.core.windows.net/zadanie/Inventory.csv", "Inventory.csv");
                var inventory = await _inventoryService.ProcessInventoryFileAsync(inventoryFilePath);

                // Step 3: Download Prices.csv and Save data to DB
                var priceFilePath = await _fileDownloadService.DownloadCsvAsync("https://rekturacjazadanie.blob.core.windows.net/zadanie/Prices.csv", "Prices.csv");
                var prices = await _priceService.ProcessPriceFileAsync(priceFilePath);

                // After processing all files
                return Ok(new { message = "All files downloaded and data saved successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error processing files", error = ex.Message });
            }
        }
    }
}
