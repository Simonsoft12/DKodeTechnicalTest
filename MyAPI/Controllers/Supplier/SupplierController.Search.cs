using Microsoft.AspNetCore.Mvc;

namespace MyAPI.Controllers.Supplier
{
    public partial class SupplierController
    {

        [HttpGet("supplier-summary")]
        public async Task<IActionResult> GetSupplierSummary([FromQuery] string supplierName)
        {
            try
            {
                var supplierSummary = await _supplierService.GetSupplierSummaryAsync(supplierName);
                return Ok(supplierSummary);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error retrieving supplier summary", error = ex.Message });
            }
        }
    }
}
