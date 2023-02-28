using OrderService.Data.Models;

namespace OrderService.Business
{
    public interface IOrderServiceBusiness
    {
        Task SaveOrder(OrderDTO orders);
        Task SaveOrders(List<OrderDTO> orders);
    }
}