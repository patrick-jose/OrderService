using Dapper;
using Npgsql;
using OrderService.Data.Models;
using OrderService.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private const string CONNECTION_STRING = "Host=localhost:5455;" +
                   "Username=postgresUser;" +
                   "Password=postgresPW;" +
                   "Database=OrdersDB";

        private readonly NpgsqlConnection connection;
        private readonly ILogWriter _log;
        private readonly ICustomerRepository _customerRepository;

        public ProductRepository(ILogWriter log)
        {
            connection = new NpgsqlConnection(CONNECTION_STRING);
            connection.Open();
            _log = log;
        }

        public async Task<ProductModel> GetProductAsync(long id)
        {
            try
            {
                string commandText = $"select * from Orders.product p " +
                                    "where p.id = @id";

                var queryArgs = new { id = id };

                var result = await connection.QueryFirstOrDefaultAsync<ProductModel>(commandText, queryArgs);
                return result;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw ex;
            }
        }

        public async Task<ProductModel> GetProductByNameAsync(string name)
        {
            try
            {
                string commandText = $"select * from Orders.product p " +
                                    "where p.name = @name";

                var queryArgs = new { name = FormalizeString.UppercaseWords(FormalizeString.RemoveDiacritics(name)), };

                var result = await connection.QueryFirstOrDefaultAsync<ProductModel>(commandText, queryArgs);
                return result;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw ex;
            }
        }

        public async Task<int> InsertProductAsync(ProductModel product)
        {
            try
            {
                string commandText = $"INSERT INTO Orders.product (name, price) VALUES (@name, @price)";

                var queryArguments = new
                {
                    name = FormalizeString.UppercaseWords(FormalizeString.RemoveDiacritics(product.Name)),
                    price = product.Price
                };

                return await connection.ExecuteAsync(commandText, queryArguments);
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw ex;
            }
        }
    }
}
