using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTOs;
using Application.IRepositories;
using Application.IServices;
using Domain;
using Domain.Enum;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductVariantRepository _productVariantRepository;
        private readonly IProductImageRepository _productImageRepository;
        public ProductService(IProductRepository productRepository, 
            IProductVariantRepository productVariantRepository, 
            IProductImageRepository productImageRepository)
        {
            _productRepository = productRepository;
            _productVariantRepository = productVariantRepository;
            _productImageRepository = productImageRepository;
        }

        private static ProductDTO MapToDTO(Product product)
        {
            if (product == null) return null;
            return new ProductDTO
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,            
                BasePrice = product.BasePrice,
                CreatedDate = product.CreatedDate,
                UpdatedDate = product.UpdatedDate,
                CategoryId = product.CategoryId,
                ProductImages = product.ProductImages?.Select(pi => new ProductImageDTO
                {
                    ProductImageId = pi.ProductImageId,
                    ImageUrl = pi.ImageUrl,
                    ProductId = product.ProductId
                }).ToList(),
                ProductVariants = product.ProductVariants?.Select(pv => new ProductVariantDTO
                {
                    ProductVariantId = pv.ProductVariantId,
                    ProductId = product.ProductId,
                    Region = pv.Region,
                    RoastType = pv.RoastType,
                    Size = pv.Size,
                    Taste = pv.Taste,
                    Price = pv.Price
                }).ToList()
            };
        }
        private static ProductVariantDTO MapToVariantDTO(ProductVariant productVariant)
        {
            if (productVariant == null) return null;
            return new ProductVariantDTO
            {
                ProductVariantId = productVariant.ProductVariantId,
                ProductId = productVariant.ProductId,
                Region = productVariant.Region,
                RoastType = productVariant.RoastType,
                Size = productVariant.Size,
                Taste = productVariant.Taste,
                Price = productVariant.Price
            };
        }
        public async Task<ProductDTO> AddProductAsync(ProductDTO productDTO)
        {
            var product = new Product
            {
                ProductId = Guid.NewGuid().ToString(),
                Name = productDTO.Name,
                Description = productDTO.Description,
                BasePrice = productDTO.BasePrice,
                CreatedDate = DateTimeOffset.Now,
                UpdatedDate = productDTO.UpdatedDate,
                CategoryId = productDTO.CategoryId,
                ProductImages = productDTO.ProductImages?.Select(pi => new ProductImage
                {
                    ProductImageId = Guid.NewGuid().ToString(),
                    ImageUrl = pi.ImageUrl,
                    ProductId = productDTO.ProductId
                }).ToList(),
                ProductVariants = productDTO.ProductVariants?.Select(pv => new ProductVariant
                {
                    ProductVariantId = Guid.NewGuid().ToString(),
                    ProductId = productDTO.ProductId,
                    Region = pv.Region,
                    RoastType = pv.RoastType,
                    Size = pv.Size,
                    Taste = pv.Taste,
                    Price = pv.Price
                }).ToList()
            };

            await _productRepository.AddProductAsync(product);
            return MapToDTO(product);
        }

        public async Task<ProductVariantDTO> AddProductVariantAsync(string productId, ProductVariantDTO productVariantDTO)
        {
            var product = await _productRepository.GetProductByIdAsync(productId);
            if (product == null)
            {
                throw new Exception("Product not found");
            }
            var productVariant = new ProductVariant
            {
                ProductVariantId = Guid.NewGuid().ToString(),
                ProductId = productId,
                Region = productVariantDTO.Region,
                RoastType = productVariantDTO.RoastType,
                Size = productVariantDTO.Size,
                Taste = productVariantDTO.Taste,
                Price = productVariantDTO.Price
            };
            await _productVariantRepository.AddProductVariantAsync(productVariant);
            return MapToVariantDTO(productVariant);
        }

        public async Task DeleteProductAsync(string id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null)
            {
                throw new Exception("Product not found");
            }
            if (product.ProductImages != null)
            {
                foreach (var productImage in product.ProductImages)
                {
                    await _productImageRepository.DeleteProductImageAsync(productImage.ProductImageId);
                }
            }
            if(product.ProductVariants != null)
            {
                foreach (var productVariant in product.ProductVariants)
                {
                    await _productVariantRepository.DeleteProductVariantAsync(productVariant.ProductVariantId);
                }
            }
            await _productRepository.DeleteProductAsync(id);
        }

        public async Task DeleteProductVariantAsync(string id)
        {
            var productVariant = await _productVariantRepository.GetVariantByIdAsync(id);
            if (productVariant == null)
            {
                throw new Exception("Product variant not found");
            }
            await _productVariantRepository.DeleteProductVariantAsync(id);
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return products.Select(MapToDTO);
        }

        public async Task<ProductDTO> GetProductByIdAsync(string id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            return MapToDTO(product);
        }

        public async Task<ProductVariantDTO> GetProductVariantByIdAsync(string id)
        {
            var productVariant = await _productVariantRepository.GetVariantByIdAsync(id);
            return MapToVariantDTO(productVariant);
        }

        public async Task UpdateProductAsync(string id, UpdateProductDTO updateProductDTO)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null)
            {
                throw new Exception("Product not found");
            }
            product.Name = updateProductDTO.Name;
            product.Description = updateProductDTO.Description;
            product.BasePrice = updateProductDTO.BasePrice;
            product.UpdatedDate = DateTimeOffset.Now;

            await _productRepository.UpdateProductAsync(product);
        }

        public async Task UpdateProductVariantAsync(string id, ProductVariantDTO productVariantDTO)
        {
            var productVariant = await _productVariantRepository.GetVariantByIdAsync(id);
            if (productVariant == null)
            {
                throw new Exception("Product variant not found");
            }
            productVariant.Region = productVariantDTO.Region;
            productVariant.RoastType = productVariantDTO.RoastType;
            productVariant.Size = productVariantDTO.Size;
            productVariant.Taste = productVariantDTO.Taste;
            productVariant.Price = productVariantDTO.Price;

            await _productVariantRepository.UpdateProductVariantAsync(productVariant);
        }
    }
}
