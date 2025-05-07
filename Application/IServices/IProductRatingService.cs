using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTOs;

namespace Application.IServices
{
    public interface IProductRatingService
    {
        Task<ProductRatingDTO> RateProductAsync(string userId, string productId, int rating, string comment);
    }
}
