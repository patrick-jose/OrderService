using OrderService.Data.Models;

namespace OrderService.Data.Repository
{
    public interface IOrdersRepository
    {
        Task<CustomerOrderModel> GetOrderAsync(long id);
        Task<int> InsertCustomerOrderAsync(CustomerOrderModel order);
        Task<int> InsertOrderAsync(long orderId);
    }
}