using OrderService.Business;
using OrderService.Data.Models;
using OrderService.Data.Repository;
using OrderService.Utils;
using Xunit.Sdk;

namespace TestProject
{
    [TestClass]
    public class ProductTest
    {
        private ProductRepository _productRepository;
        private ILogWriter _log;

        [TestMethod]
        public void GetProductRepositoryTest()
        {
            _log = new LogWriter();
            _productRepository = new ProductRepository(_log);

            var result = _productRepository.GetProductAsync(2);

            Assert.IsNotNull(result.Result);
        }

        [TestMethod]
        public void InsertProductRepositoryTest()
        {
            _log = new LogWriter();
            _productRepository = new ProductRepository(_log);

            var product = new ProductModel { Name = "régua", Price = 7.9M };

            var result = _productRepository.InsertProductAsync(product);

            Assert.IsNotNull(result.Result);
            Assert.IsTrue(result.Result > 0);
        }
    }
}