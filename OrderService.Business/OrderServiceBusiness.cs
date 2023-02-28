using OrderService.Data.Models;
using OrderService.Data.Repository;
using OrderService.Utils;

namespace OrderService.Business
{
    public class OrderServiceBusiness : IOrderServiceBusiness
    {
        private readonly IOrdersRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly ILogWriter _log;

        public OrderServiceBusiness(IOrdersRepository ordersRepository, ILogWriter log, IProductRepository productRepository)
        {
            _orderRepository = ordersRepository;
            _log = log;
            _productRepository = productRepository;
        }

        public async Task SaveOrder(OrderDTO orderDTO)
        {
            try
            {
                var productModel = new ProductModel();

                foreach (var product in orderDTO.Items)
                {
                    if (product.id == 0)
                    {
                        productModel = await _productRepository.GetProductByNameAsync(product.Name);
                        product.id = productModel.Id;
                    }
                }

                var orderModel = orderDTO.ToModel();

                foreach (var order in orderModel)
                    await _orderRepository.InsertCustomerOrderAsync(order);
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw ex;
            }
        }

        public async Task SaveOrders(List<OrderDTO> orders)
        {
            try
            {
                foreach (var order in orders)
                    await SaveOrder(order);
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw ex;
            }
        }
    }
}