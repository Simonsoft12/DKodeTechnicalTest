using Microsoft.AspNetCore.Mvc;
using MyAPI.Services.SupplierService;

namespace MyAPI.Controllers.Supplier
{
    [ApiController]
    [Route("api/[controller]")]
    public partial class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }
    }
}
