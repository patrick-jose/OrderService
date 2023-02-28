using OrderService.Data.Models;
using OrderService.Data.Repository;
using OrderService.Utils;

namespace OrderService.Business
{
    public class OrderServiceBusiness : IOrderServiceBusiness
    {
        private readonly IOrdersRepository _orderRepository;
        private readonly ILogWriter _log;

        public OrderServiceBusiness(IOrdersRepository ordersRepository, ILogWriter log)
        {
            _orderRepository = ordersRepository;
            _log = log;
        }

        public async Task SaveOrder(OrderDTO orderDTO)
        {
            try
            {
                var orderModel = orderDTO.ToModel();

                foreach(var order in orderModel) 
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