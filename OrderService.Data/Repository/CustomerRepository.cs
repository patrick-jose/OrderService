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
    public class CustomerRepository : ICustomerRepository
    {
        private const string CONNECTION_STRING = "Host=localhost:5455;" +
                   "Username=postgresUser;" +
                   "Password=postgresPW;" +
                   "Database=OrdersDB";

        private readonly NpgsqlConnection connection;
        private readonly ILogWriter _log;

        public CustomerRepository(ILogWriter log)
        {
            connection = new NpgsqlConnection(CONNECTION_STRING);
            connection.Open();
            _log = log;
        }

        public async Task<CustomerModel> GetCustomerAsync(long id)
        {
            try
            {
                string commandText = $"select * from Orders.customer c " +
                                    "where c.id = @id";

                var queryArgs = new { id = id };

                var result = await connection.QueryFirstOrDefaultAsync<CustomerModel>(commandText, queryArgs);
                return result;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw ex;
            }
        }

        public async Task<int> InsertCustomerAsync(CustomerModel customer)
        {
            try
            {
                string commandText = @$"INSERT INTO Orders.customer (id, name)
                                    VALUES (@id, @name)";

                var queryArguments = new
                {
                    id = customer.Id,
                    name = customer.Name
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
