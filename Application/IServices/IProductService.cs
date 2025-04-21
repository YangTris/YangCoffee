using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTOs;

namespace Application.IServices
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        public Task<ProductDTO> GetProductByIdAsync(string id);
        public Task<ProductDTO> AddProductAsync(ProductDTO productDTO);
        public Task UpdateProductAsync(string id, UpdateProductDTO updateProductDTO);
        public Task DeleteProductAsync(string id);
        public Task<ProductVariantDTO> AddProductVariantAsync(string productId, ProductVariantDTO productVariantDTO);
        public Task<ProductVariantDTO> GetProductVariantByIdAsync(string id);
        public Task UpdateProductVariantAsync(string id, ProductVariantDTO productVariantDTO);
        public Task DeleteProductVariantAsync(string id);
    }
}
