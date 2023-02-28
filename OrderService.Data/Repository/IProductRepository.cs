using OrderService.Data.Models;

namespace OrderService.Data.Repository
{
    public interface IProductRepository
    {
        Task<ProductModel> GetProductAsync(long id);
        Task<ProductModel> GetProductByNameAsync(string name);
        Task<int> InsertProductAsync(ProductModel product);
    }
}