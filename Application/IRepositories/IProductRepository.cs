using Domain;

namespace Application.IRepositories
{
    public interface IProductRepository
    {
        Task<(IEnumerable<Product> Products, int TotalItems)> GetProductByQueryAsync(string? searchString, string[]? categoryId, string? sortBy, int page = 1, int pageSize = 6);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(string id);
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(string id);
    }
}
