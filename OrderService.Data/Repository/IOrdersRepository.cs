using OrderService.Data.Models;

namespace OrderService.Data.Repository
{
    public interface IOrdersRepository
    {
        Task<IEnumerable<CustomerOrderModel>> Get(int id);
        Task<int> Insert(CustomerOrderModel order);
    }
}