using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace MyAPI.Repositories.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task InsertOrUpdateProductsAsync(List<Entities.Product> products)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    // Creating a DataTable for mapping TVP
                    var productTable = new DataTable();
                    productTable.Columns.Add("ProductId", typeof(int));
                    productTable.Columns.Add("SKU", typeof(string));
                    productTable.Columns.Add("Name", typeof(string));
                    productTable.Columns.Add("EAN", typeof(string));
                    productTable.Columns.Add("ProducerName", typeof(string));
                    productTable.Columns.Add("MainCategory", typeof(string));
                    productTable.Columns.Add("SubCategory", typeof(string));
                    productTable.Columns.Add("ChildCategory", typeof(string));
                    productTable.Columns.Add("IsWire", typeof(int));
                    productTable.Columns.Add("Shipping", typeof(string));
                    productTable.Columns.Add("Available", typeof(int));
                    productTable.Columns.Add("IsVendor", typeof(int));
                    productTable.Columns.Add("DefaultImage", typeof(string));

                    foreach (var product in products)
                    {
                        productTable.Rows.Add(
                            product.ProductId,
                            product.SKU,
                            product.Name,
                            product.EAN,
                            product.ProducerName,
                            product.MainCategory,
                            product.SubCategory,
                            product.ChildCategory,
                            product.IsWire,
                            product.Shipping,
                            product.Available,
                            product.IsVendor.HasValue ? (product.IsVendor.Value ? 1 : 0) : DBNull.Value,
                            product.DefaultImage
                        );
                    }

                    var parameters = new DynamicParameters();
                    parameters.Add("@Products", productTable.AsTableValuedParameter("dbo.ProductType"));

                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            await connection.ExecuteAsync("dbo.InsertOrUpdateProducts", parameters, transaction: transaction, commandType: CommandType.StoredProcedure);

                            transaction.Commit();
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                throw new Exception("SQL error while inserting/updating products.", sqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception("ProductRepository-InsertOrUpdateProductsAsync", ex);
            }
        }
    }
}
