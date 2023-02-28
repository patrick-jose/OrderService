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
    public class OrdersRepository : IOrdersRepository
    {
        private const string CONNECTION_STRING = "Host=localhost:5455;" +
                   "Username=postgresUser;" +
                   "Password=postgresPW;" +
                   "Database=OrdersDB";

        private readonly NpgsqlConnection connection;
        private readonly ILogWriter _log;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;

        public OrdersRepository(ILogWriter log, ICustomerRepository customerRepository, IProductRepository productRepository)
        {
            connection = new NpgsqlConnection(CONNECTION_STRING);
            connection.Open();
            _log = log;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }

        public async Task<CustomerOrderModel> GetOrderAsync(long id)
        {
            try
            {
                string commandText = $"select * from Orders.\"Order\" co " +
                                    "where co.id = @id";

                var queryArgs = new { id = id };

                var result = await connection.QueryFirstOrDefaultAsync<CustomerOrderModel>(commandText, queryArgs);
                return result;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw ex;
            }
        }

        public async Task<int> InsertCustomerOrderAsync(CustomerOrderModel order)
        {
            try
            {
                var insertSuccess = 1;
                var checkOrderExists = await GetOrderAsync(order.OrderId);
                var checkCustomerExists = await _customerRepository.GetCustomerAsync(order.CustomerId);

                if (checkOrderExists == null)
                    insertSuccess = await InsertOrderAsync(order.OrderId);
                if (checkCustomerExists == null && insertSuccess == 1)
                    insertSuccess = await _customerRepository.InsertCustomerAsync(new CustomerModel() { Id = order.CustomerId, Name = order.CustomerName });

                if (insertSuccess == 1)
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

                return 0;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw ex;
            }
        }

        public async Task<int> InsertOrderAsync(long orderId)
        {
            try
            {
                string commandText = $"INSERT INTO Orders.\"Order\" (id) VALUES (@id)";

                var queryArguments = new
                {
                    id = orderId
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
