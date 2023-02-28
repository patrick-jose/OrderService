using Moq;
using OrderService.Business;
using OrderService.Data.Models;
using OrderService.Data.Repository;
using OrderService.Utils;
using Xunit.Sdk;

namespace TestProject
{
    [TestClass]
    public class OrdersTest
    {
        private IOrdersRepository _ordersRepository;
        private IOrderServiceBusiness _orderServiceBusiness;
        private ICustomerRepository _customerRepository;
        private IProductRepository _productRepository;
        private ILogWriter _log;

        [TestMethod]
        public void GetOrderRepositoryTest()
        {
            _log = new LogWriter();
            _customerRepository = new Mock<CustomerRepository>().Object;
            _ordersRepository = new OrdersRepository(_log, _customerRepository);

            var result = _ordersRepository.GetOrderAsync(2);

            Assert.IsNotNull(result.Result);
        }

        [TestMethod]
        public void InsertOrderRepositoryTest()
        {
            _log = new LogWriter();
            _customerRepository = new Mock<CustomerRepository>().Object;
            _ordersRepository = new OrdersRepository(_log, _customerRepository);

            var order = new CustomerOrderModel { CustomerId = 3, OrderId = 1001, ProductId = 3, Quantity = 5, UnitaryPrice = 12.4m };

            var result = _ordersRepository.InsertCustomerOrderAsync(order);

            Assert.IsNotNull(result.Result);
            Assert.IsTrue(result.Result > 0);
        }

        [TestMethod]
        public async Task InsertOrderBusinessTest()
        {
            _log = new LogWriter();
            _customerRepository = new CustomerRepository(_log);
            _productRepository = new ProductRepository(_log);
            _ordersRepository = new OrdersRepository(_log, _customerRepository);
            _orderServiceBusiness = new OrderServiceBusiness(_ordersRepository, _log, _productRepository);

            var testModel1 = new OrderDTO()
            {
                Id = 1003,
                customer = new CustomerDTO() { Id = 10, Name = "John Doe" },
                Items = new List<ProductDTO> {
                    new ProductDTO() { Name = "Lapis", Price = 12.9M, Quantity = 2},
                    new ProductDTO() { Name = "Estojo", Price = 7.99M, Quantity = 5},
                    new ProductDTO() { Name = "Borracha", Price = 0.5M, Quantity = 3},
                }
            };

            var testModel2 = new OrderDTO()
            {
                Id = 1004,
                customer = new CustomerDTO() { Id = 11, Name = "Test Now" },
                Items = new List<ProductDTO> {
                    new ProductDTO() { id = 2, Name = "Lapis", Price = 12.9M, Quantity = 2},
                }
            };

            var testModel3 = new OrderDTO()
            {
                Id = 1005,
                customer = new CustomerDTO() { Id = 12, Name = "Jone Doe" },
                Items = new List<ProductDTO> {
                    new ProductDTO() { id = 1, Name = "Caderno", Price = 10, Quantity = 2},
                    new ProductDTO() { id = 4, Name = "Fita Durex", Price = 5, Quantity = 2},
                    new ProductDTO() { id = 5, Name = "Envelope Pardo", Price = 0.25M, Quantity = 10},
                    new ProductDTO() { id = 6, Name = "Borracha", Price = 0.5M, Quantity = 1},
                    new ProductDTO() { id = 3, Name = "Caneta", Price = 1, Quantity = 2},
                }
            };

            var listTestModel = new List<OrderDTO>() { testModel1, testModel2, testModel3 };

            await _orderServiceBusiness.SaveOrders(listTestModel);

            Assert.IsTrue(_ordersRepository.GetOrderAsync(1003).Result != null);
            Assert.IsTrue(_ordersRepository.GetOrderAsync(1004).Result != null);
            Assert.IsTrue(_ordersRepository.GetOrderAsync(1005).Result != null);
        }
    }
}