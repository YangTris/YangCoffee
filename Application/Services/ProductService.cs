using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Application.IRepositories;
using Application.IServices;
using Domain;
using static System.Net.Mime.MediaTypeNames;

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
                CategoryId = product.CategoryId,
                BaseImageUrl = product.BaseImageUrl,
                CreatedDate = product.CreatedDate,
                UpdatedDate = product.UpdatedDate,
                ProductVariants = product.ProductVariants.Select(MapToVariantDTO).ToList()
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
                Price = productVariant.Price,
                RoastType = productVariant.RoastType,
                Size = productVariant.Size,
                Taste = productVariant.Taste,
                ImageUrl = productVariant.ImageUrl?.Select(MapToImageDTO).ToList()
            };
        }

        private static ProductImageDTO MapToImageDTO(ProductImage productImage)
        {
            if (productImage == null) return null;

            return new ProductImageDTO
            {
                ImageUrl = productImage.ImageUrl,
                ProductVariantId = productImage.ProductVariantId
            };
        }

        //public async Task<ProductDTO> AddProductAsync(ProductDTO productDTO)
        //{
        //    var product = new Product
        //    {
        //        ProductId = Guid.NewGuid().ToString(),
        //        Name = productDTO.Name,
        //        Description = productDTO.Description,
        //        BasePrice = productDTO.BasePrice,
        //        CategoryId = productDTO.CategoryId,
        //        BaseImageUrl = productDTO.BaseImageUrl,
        //        CreatedDate = DateTime.Now,
        //        UpdatedDate = DateTime.Now,
        //        ProductVariants = productDTO.ProductVariants.Select(pv => new ProductVariant
        //        {
        //            ProductVariantId = Guid.NewGuid().ToString(),
        //            Region = pv.Region,
        //            Price = pv.Price,
        //            RoastType = pv.RoastType,
        //            Size = pv.Size,
        //            Taste = pv.Taste,
        //            ImageUrl = pv.ImageUrl.Select(i => new ProductImage
        //            {
        //                ProductImageId = Guid.NewGuid().ToString(),
        //                ImageUrl = i.ImageUrl,
        //            }).ToList()
        //        }).ToList()
        //    };
        //    await _productRepository.AddProductAsync(product);

        //    if(product.ProductVariants != null)
        //    {
        //        foreach (var variant in product.ProductVariants)
        //        {
        //            variant.ProductId = product.ProductId;

        //            await _productVariantRepository.AddProductVariantAsync(variant);
        //            if(variant.ImageUrl!= null)
        //            {
        //                foreach (var image in variant.ImageUrl)
        //                {
        //                    image.ProductVariantId = variant.ProductVariantId;

        //                    await _productImageRepository.AddProductImageAsync(image);
        //                }
        //            }
        //        }
        //    }
            
        //    return MapToDTO(product);
        //}

        //public async Task<ProductVariantDTO> AddProductVariantAsync(string productId, ProductVariantDTO productVariantDTO)
        //{
        //    var product = await _productRepository.GetProductByIdAsync(productId);
        //    if (product == null)
        //    {
        //        return null;
        //    }

        //    var productVariant = new ProductVariant
        //    {
        //        ProductVariantId = Guid.NewGuid().ToString(),
        //        ProductId = productId,
        //        Region = productVariantDTO.Region,
        //        Price = productVariantDTO.Price,
        //        RoastType = productVariantDTO.RoastType,
        //        Size = productVariantDTO.Size,
        //        Taste = productVariantDTO.Taste,
        //        ImageUrl = productVariantDTO.ImageUrl?.Select(i => new ProductImage
        //        {
        //            ProductImageId = Guid.NewGuid().ToString(),
        //            ImageUrl = i.ImageUrl,
        //            ProductVariantId = null
        //        }).ToList()
        //    };

        //    await _productVariantRepository.AddProductVariantAsync(productVariant);

        //    if (productVariant.ImageUrl != null)
        //    {
        //        foreach (var image in productVariant.ImageUrl)
        //        {
        //            image.ProductVariantId = productVariant.ProductVariantId;
        //            await _productImageRepository.AddProductImageAsync(image);
        //        }
        //    }

        //    return MapToVariantDTO(productVariant);
        //}

        public async Task DeleteProductAsync(string id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product != null)
            {
                foreach(var variant in product.ProductVariants)
                {
                    await DeleteProductVariantAsync(variant.ProductVariantId);
                }
                await _productRepository.DeleteProductAsync(id);
            }
        }

        public async Task DeleteProductVariantAsync(string id)
        {
            var productVariant = await _productVariantRepository.GetVariantByIdAsync(id);
            if (productVariant != null)
            {
                if(productVariant.ImageUrl != null)
                {
                    foreach (var image in productVariant.ImageUrl)
                    {
                        await _productImageRepository.DeleteProductImageAsync(image.ImageUrl);
                    }
                }
                await _productVariantRepository.DeleteProductVariantAsync(id);
            }
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var product = await _productRepository.GetAllProductsAsync();
            return product.Select(MapToDTO);
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
            if (product != null)
            {
                product.Name = updateProductDTO.Name;
                product.Description = updateProductDTO.Description;
                product.BasePrice = updateProductDTO.BasePrice;
                product.BaseImageUrl = updateProductDTO.BaseImageUrl;
                product.CreatedDate = updateProductDTO.CreatedDate;
                product.UpdatedDate = DateTime.UtcNow;

                await _productRepository.UpdateProductAsync(product);
            }
        }

        public async Task UpdateProductVariantAsync(string id,ProductVariantDTO productVariantDTO)
        {
            var productVariant = await _productVariantRepository.GetVariantByIdAsync(id);
            if (productVariant != null)
            {
                productVariant.Region = productVariantDTO.Region;
                productVariant.Price = productVariantDTO.Price;
                productVariant.RoastType = productVariantDTO.RoastType;
                productVariant.Size = productVariantDTO.Size;
                productVariant.Taste = productVariantDTO.Taste;
                productVariant.ImageUrl = productVariantDTO.ImageUrl.Select(i => new ProductImage
                {
                    ImageUrl = i.ImageUrl,
                    ProductVariantId = id
                }).ToList();

                await _productVariantRepository.UpdateProductVariantAsync(productVariant);
            }
        }

        public async Task<ProductDTO> AddProductAsync(ProductDTO productDTO)
        {
            var product = new Product
            {
                ProductId = Guid.NewGuid().ToString(),
                Name = productDTO.Name,
                Description = productDTO.Description,
                BasePrice = productDTO.BasePrice,
                CategoryId = productDTO.CategoryId,
                BaseImageUrl = productDTO.BaseImageUrl,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                ProductVariants = productDTO.ProductVariants.Select(pv => new ProductVariant
                {
                    ProductVariantId = Guid.NewGuid().ToString(),
                    Region = pv.Region,
                    Price = pv.Price,
                    RoastType = pv.RoastType,
                    Size = pv.Size,
                    Taste = pv.Taste,
                    ProductId = productDTO.ProductId
                }).ToList()
            };
            await _productRepository.AddProductAsync(product);
            if (product.ProductVariants != null)
            {
                foreach (var variant in product.ProductVariants)
                {
                    //variant.ProductId = product.ProductId;
                    await _productVariantRepository.AddProductVariantAsync(variant);
                    if (variant.ImageUrl != null)
                    {
                        foreach (var image in variant.ImageUrl)
                        {
                            image.ProductVariantId = variant.ProductVariantId;
                            await _productImageRepository.AddProductImageAsync(image);
                            MapToImageDTO(image);
                        }
                    }
                    MapToVariantDTO(variant);
                }
            }
            return MapToDTO(product);
        }

        public Task<ProductVariantDTO> AddProductVariantAsync(string productId, ProductVariantDTO productVariantDTO)
        {
            throw new NotImplementedException();
        }
    }
}
