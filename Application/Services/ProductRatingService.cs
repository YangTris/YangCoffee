using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IRepositories;
using Application.IServices;
using Domain;
using Shared.DTOs;

namespace Application.Services
{
    public class ProductRatingService: IProductRatingService
    {
        private readonly IProductRatingRepository _productRatingRepository;
        public ProductRatingService(IProductRatingRepository productRatingRepository)
        {
            _productRatingRepository = productRatingRepository;
        }

        private static ProductRatingDTO MapToDTO(ProductRating rating)
        {
            if (rating == null)
            {
                return null;
            }

            return new ProductRatingDTO
            {
                ProductRatingId = rating.ProductRatingId,
                UserId = rating.UserId,
                ProductId = rating.ProductId,
                Rating = rating.Rating,
                Comment = rating.Comment,
                CreatedDate = rating.CreatedDate
            };
        }

        public async Task<ProductRatingDTO> RateProductAsync(string userId, string productId, int rating, string comment)
        {
            var existing = await _productRatingRepository.GetUserRatingForProductAsync(userId, productId);
            if (existing != null) return null;

            var newRating = new ProductRating
            {
                ProductRatingId = Guid.NewGuid().ToString(),
                UserId = userId,
                ProductId = productId,
                Rating = rating,
                Comment = comment,
                CreatedDate = DateTimeOffset.UtcNow
            };

            await _productRatingRepository.AddAsync(newRating);
            return MapToDTO(newRating);
        }
    }
}
