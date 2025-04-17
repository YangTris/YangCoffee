using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Application.IRepositories
{
    public interface IProductVariantRepository
    {
        Task<IEnumerable<ProductVariant>> GetAllVariantByProductIdAsync(string productId);
        Task AddProductVariantAsync(ProductVariant productVariant);
        Task UpdateProductVariantAsync(ProductVariant productVariant);
        Task DeleteProductVariantAsync(string id);
    }
}
