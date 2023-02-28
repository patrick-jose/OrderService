using Dapper;
using Npgsql;
using OrderService.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Data.Repository
{
    public class OrdersRepository : IOrdersRepository
    {
        private const string CONNECTION_STRING = "Host=localhost:5455;" +
                   "Username=postgresUser;" +
                   "Password=postgresPW;" +
                   "Database=OrdersDB";

        private readonly NpgsqlConnection connection;

        public OrdersRepository()
        {
            connection = new NpgsqlConnection(CONNECTION_STRING);
            connection.Open();
        }

        public async Task<IEnumerable<CustomerOrderModel>> Get(int id)
        {
            try
            {
                string commandText = @$"select * from Orders.CustomerOrder co 
                                    where co.OrderId = @id";

                var queryArgs = new { Id = id };

                var result = await connection.QueryAsync<CustomerOrderModel>(commandText, queryArgs);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Insert(CustomerOrderModel order)
        {
            try
            {
                string commandText = @$"INSERT INTO Orders.CustomerOrder (orderid, customerid, quantity, productid, unitaryprice)
                                        VALUES (@orderid, @customerid, @quantity, @productid, @unitaryprice)";

                var queryArguments = new
                {
                    orderid = order.OrderId,
                    customerid = order.CustomerId,
                    quantity = order.Quantity,
                    productid = order.ProductId,
                    unitaryprice = order.UnitaryPrice
                };

                return await connection.ExecuteAsync(commandText, queryArguments);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
