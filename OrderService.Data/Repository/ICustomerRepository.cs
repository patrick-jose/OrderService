using OrderService.Data.Models;

namespace OrderService.Data.Repository
{
    public interface ICustomerRepository
    {
        Task<CustomerModel> GetCustomerAsync(long id);
        Task<int> InsertCustomerAsync(CustomerModel customer);
    }
}