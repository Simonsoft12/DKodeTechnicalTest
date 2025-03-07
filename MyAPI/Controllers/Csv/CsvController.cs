using Microsoft.AspNetCore.Mvc;
using MyAPI.Services.FileDownloadService;
using MyAPI.Services.ProductService;
using MyAPI.Services.InventoryService;
using MyAPI.Services.PriceService;

namespace MyAPI.Controllers.Csv
{
    [ApiController]
    [Route("api/[controller]")]
    public partial class CsvController : ControllerBase
    {
        private readonly IFileDownloadService _fileDownloadService;
        private readonly IProductService _productService;
        private readonly IInventoryService _inventoryService;
        private readonly IPriceService _priceService;

        public CsvController(
            IFileDownloadService fileDownloadService,
            IProductService productService,
            IInventoryService inventoryService,
            IPriceService priceService)
        {
            _fileDownloadService = fileDownloadService;
            _productService = productService;
            _inventoryService = inventoryService;
            _priceService = priceService;
        }
    }
}
