using Shared.DTOs;
using Application.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAll()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("query")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetByQuery([FromQuery] ProductQuery productQuery)
        {
            if (productQuery.PageNumber < 1 || productQuery.PageSize < 1)
                return BadRequest("PageNumber and PageSize must be greater than 0.");

            var allowedSorts = new[] { "createddate", "price", "name" };
            if (!string.IsNullOrEmpty(productQuery.SortBy) &&
                !allowedSorts.Contains(productQuery.SortBy.ToLower()))
            {
                return BadRequest("Invalid sort value.");
            }

            var products = await _productService.GetProductByQueryAsync(
            productQuery.CategoryId, productQuery.SortBy, productQuery.PageNumber, productQuery.PageSize);
            
            return Ok(products);
        }

        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Search(
            [FromQuery] string? searchName,
            [FromQuery] string? sortBy,
            [FromQuery] bool isDescending = false,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 6,
            [FromQuery] decimal? price = null,
            [FromQuery] string[]? size = null,
            [FromQuery] string[]? region = null)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var products = await _productService.GetAllProductsAsync();

            // Search
            if (!string.IsNullOrWhiteSpace(searchName))
            {
                products = products.Where(p => p.Name.Contains(searchName, StringComparison.OrdinalIgnoreCase));
            }

            // Filter by Price
            if (price.HasValue)
            {
                products = price switch
                {
                    <= 15m => products.Where(p => p.BasePrice <= 15m ),
                    <= 20m => products.Where(p => p.BasePrice > 15m && p.BasePrice <= 20m),
                    > 20m => products.Where(p => p.BasePrice > 20m),
                    _ => products
                };
            }

            // Filter by Bag Weight
            if (size != null && size.Any())
            {
                products = products.Where(p => p.ProductVariants.Any(v => size.Contains(v.Size.ToString())));
            }

            // Filter by Region
            if (region != null && region.Any())
            {
                products = products.Where(p => p.ProductVariants.Any(v => region.Contains(v.Region.ToString())));
            }

            // Sort
            products = sortBy?.ToLower() switch
            {
                "name" => isDescending ? products.OrderByDescending(p => p.Name) : products.OrderBy(p => p.Name),
                "price" => isDescending ? products.OrderByDescending(p => p.BasePrice) : products.OrderBy(p => p.BasePrice),
                "createddate" => isDescending ? products.OrderByDescending(p => p.CreatedDate) : products.OrderBy(p => p.CreatedDate),
                _ => products.OrderByDescending(p => p.CreatedDate) // Default sort
            };

            // Paging
            var totalItems = products.Count();
            var pagedProducts = products
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Result
            var result = new
            {
                TotalItems = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize),
                Items = pagedProducts
            };

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductDTO>> GetById(string id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromBody] ProductDTO productDTO)
        {
            if (productDTO == null)
            {
                return BadRequest();
            }
            var product = await _productService.AddProductAsync(productDTO);
            return CreatedAtAction(nameof(GetById), new { id = product.ProductId }, product);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(string id, [FromBody] UpdateProductDTO updateProductDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var existingProduct = await _productService.GetProductByIdAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            await _productService.UpdateProductAsync(id, updateProductDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            await _productService.DeleteProductAsync(id);
            return NoContent();
        }

        [HttpGet("variant/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductVariantDTO>> GetProductVariantById(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productVariant = await _productService.GetProductVariantByIdAsync(id);
            if (productVariant == null)
            {
                return NotFound();
            }
            return Ok(productVariant);
        }

        [HttpPost("variant/{productId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddProductVariant(string productId, [FromBody] ProductVariantDTO productVariantDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var existingProduct = await _productService.GetProductByIdAsync(productId);
            if (existingProduct == null)
            {
                return NotFound();
            }
            var productVariant = await _productService.AddProductVariantAsync(productId, productVariantDTO);
            return CreatedAtAction(nameof(GetProductVariantById), new { id = productVariant.ProductVariantId }, productVariant);
        }

        [HttpPut("variant/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateProductVariant(string id, [FromBody] ProductVariantDTO productVariantDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var existingProductVariant = await _productService.GetProductVariantByIdAsync(id);
            if (existingProductVariant == null)
            {
                return NotFound();
            }
            await _productService.UpdateProductVariantAsync(id, productVariantDTO);
            return NoContent();
        }

        [HttpDelete("variant/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProductVariant(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productVariant = await _productService.GetProductVariantByIdAsync(id);
            if (productVariant == null)
            {
                return NotFound();
            }
            await _productService.DeleteProductVariantAsync(id);
            return NoContent();
        }

    }
}
