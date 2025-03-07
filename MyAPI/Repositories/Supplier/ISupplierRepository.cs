using MyAPI.Entities.DTOs.Supplier;

namespace MyAPI.Repositories.Supplier
{
    public interface ISupplierRepository
    {
        Task<List<SupplierSummaryDto>> GetSupplierSummaryAsync(string supplierName);
    }
}
