using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace MyAPI.Repositories.Price
{
    public class PriceRepository : IPriceRepository
    {
        private readonly string _connectionString;

        public PriceRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task InsertOrUpdatePricesAsync(List<Entities.Price> prices)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Creating a DataTable for mapping TVP
                            var priceTable = new DataTable();
                            priceTable.Columns.Add("Column1", typeof(string));
                            priceTable.Columns.Add("Column2", typeof(string));
                            priceTable.Columns.Add("Column3", typeof(decimal));
                            priceTable.Columns.Add("Column4", typeof(decimal));
                            priceTable.Columns.Add("Column5", typeof(decimal));
                            priceTable.Columns.Add("Column6", typeof(decimal));

                            foreach (var price in prices)
                            {
                                priceTable.Rows.Add(price.Column1, price.Column2, price.Column3, price.Column4, price.Column5, price.Column6);
                            }

                            var parameters = new DynamicParameters();
                            parameters.Add("@Prices", priceTable.AsTableValuedParameter("dbo.PriceType"));

                            await connection.ExecuteAsync("dbo.InsertOrUpdatePrices", parameters, transaction: transaction, commandType: CommandType.StoredProcedure);

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception("Error during insert/update operation for prices.", ex);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                throw new Exception("SQL error while inserting/updating prices.", sqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception("PriceRepository-InsertOrUpdatePricesAsync", ex);
            }
        }
    }
}
