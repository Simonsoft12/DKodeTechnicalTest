using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace MyAPI.Repositories.Inventory
{
    public partial class InventoryRepository : IInventoryRepository
    {
        private readonly string _connectionString;

        public InventoryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task InsertOrUpdateInventoryAsync(List<Entities.Inventory> inventoryItems)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Creating a DataTable for mapping TVP
                        var inventoryDataTable = new DataTable();
                        inventoryDataTable.Columns.Add("product_id", typeof(int));
                        inventoryDataTable.Columns.Add("sku", typeof(string));
                        inventoryDataTable.Columns.Add("unit", typeof(string));
                        inventoryDataTable.Columns.Add("qty", typeof(decimal));
                        inventoryDataTable.Columns.Add("manufacturer", typeof(string));
                        inventoryDataTable.Columns.Add("shipping", typeof(string));
                        inventoryDataTable.Columns.Add("shipping_cost", typeof(decimal));

                        foreach (var item in inventoryItems)
                        {
                            inventoryDataTable.Rows.Add(item.ProductId, item.SKU, item.Unit, item.Qty, item.Manufacturer, item.Shipping, item.ShippingCost);
                        }

                        var parameters = new DynamicParameters();
                        parameters.Add("@InventoryItems", inventoryDataTable.AsTableValuedParameter("dbo.InventoryType"));

                        await connection.ExecuteAsync("dbo.InsertOrUpdateInventory", parameters, transaction: transaction, commandType: CommandType.StoredProcedure);

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                throw new Exception("SQL error while inserting/updating inventory.", sqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception("InventoryRepository-InsertOrUpdateInventoryAsync", ex);
            }
        }

    }
}
