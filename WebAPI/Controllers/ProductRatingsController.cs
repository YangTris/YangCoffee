using Application.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductRatingsController : ControllerBase
    {
        private readonly IProductRatingService _productRatingService;
        public ProductRatingsController(IProductRatingService productRatingService)
        {
            _productRatingService = productRatingService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<ProductRatingDTO>> RateProduct([FromBody] ProductRatingDTO productRatingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _productRatingService.RateProductAsync(
                productRatingDto.UserId,
                productRatingDto.ProductId,
                productRatingDto.Rating,
                productRatingDto.Comment);

            if (result == null)
            {
                return Conflict("You have already rated this product.");
            }

            return CreatedAtAction(nameof(RateProduct), new { id = result.ProductRatingId }, result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ProductRatingDTO>>> GetLatestRatings(int quantity, string productId)
        {
            if (string.IsNullOrEmpty(productId))
            {
                return BadRequest("Product ID cannot be null or empty.");
            }

            if (quantity <= 0)
            {
                return BadRequest("Quantity must be greater than zero.");
            }
            
            var ratings = await _productRatingService.GetRatingAsync(quantity, productId);
 
            if (ratings == null || !ratings.Any())
            {
                return NotFound("No ratings found.");
            }
            return Ok(ratings);
        }
    }
}
