using MyAPI.Repositories.Supplier;
using MyAPI.Entities.DTOs.Supplier;

namespace MyAPI.Services.SupplierService
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        // Method to get the supplier summary based on supplier name
        public async Task<List<SupplierSummaryDto>> GetSupplierSummaryAsync(string supplierName)
        {
            try
            {
                return await _supplierRepository.GetSupplierSummaryAsync(supplierName);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving supplier summary.", ex);
            }
        }
    }
}
