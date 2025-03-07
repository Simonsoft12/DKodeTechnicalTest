using Dapper;
using MyAPI.Entities.DTOs.Supplier;
using System.Data;
using System.Data.SqlClient;

namespace MyAPI.Repositories.Supplier
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly string _connectionString;

        public SupplierRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Method to get the supplier summary based on the supplier name
        public async Task<List<SupplierSummaryDto>> GetSupplierSummaryAsync(string supplierName)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string storedProcedure = "GetSupplierSummary";
                    var parameters = new { SupplierName = supplierName };

                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            var supplierSummaries = await connection.QueryAsync<SupplierSummaryDto>(storedProcedure, parameters, commandType: CommandType.StoredProcedure, transaction: transaction);

                            if (supplierSummaries == null || !supplierSummaries.Any())
                            {
                                return new List<SupplierSummaryDto>();
                            }

                            transaction.Commit();

                            return supplierSummaries.ToList();
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("SupplierRepository-GetSupplierSummaryAsync. Error retrieving supplier data.", ex);
            }
        }
    }
}
