using OrderService.Business;
using OrderService.Data.Models;
using OrderService.Data.Repository;
using OrderService.Utils;
using Xunit.Sdk;

namespace TestProject
{
    [TestClass]
    public class CustomerTest
    {
        private CustomerRepository _customerRepository;
        private ILogWriter _log;

        [TestMethod]
        public void GetCustomerRepositoryTest()
        {
            _log = new LogWriter();
            _customerRepository = new CustomerRepository(_log);

            var result = _customerRepository.GetCustomerAsync(2);

            Assert.IsNotNull(result.Result);
        }

        [TestMethod]
        public void InsertCustomerRepositoryTest()
        {
            _log = new LogWriter();
            _customerRepository = new CustomerRepository(_log);

            var order = new CustomerModel { Id = 20, Name = "Insert Test" };

            var result = _customerRepository.InsertCustomerAsync(order);

            Assert.IsNotNull(result.Result);
            Assert.IsTrue(result.Result > 0);
        }
    }
}