using OrderService.Data.Models;
using OrderService.Data.Repository;
using Xunit.Sdk;

namespace TestProject
{
    [TestClass]
    public class OrdersTest
    {
        private IOrdersRepository _ordersRepository;

        [TestMethod]
        public void GetTest()
        {
            _ordersRepository = new OrdersRepository();

            var result = _ordersRepository.Get(2);

            Assert.IsNotNull(result.Result);
            Assert.IsTrue(result.Result.Any());
        }

        [TestMethod]
        public void InsertTest()
        {
            _ordersRepository = new OrdersRepository();

            var order = new CustomerOrderModel { CustomerId = 3, OrderId = 1001, ProductId = 3, Quantity = 5, UnitaryPrice = 12.4m };

            var result = _ordersRepository.Insert(order);

            Assert.IsNotNull(result.Result);
            Assert.IsTrue(result.Result > 0);
        }
    }
}