using MyAPI.Entities.DTOs.Supplier;

namespace MyAPI.Services.SupplierService
{
    public interface ISupplierService
    {
        Task<List<SupplierSummaryDto>> GetSupplierSummaryAsync(string supplierName);
    }
}
