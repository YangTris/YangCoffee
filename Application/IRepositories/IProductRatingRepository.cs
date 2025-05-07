using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Application.IRepositories
{
    public interface IProductRatingRepository
    {
        Task<ProductRating> GetUserRatingForProductAsync(string userId, string productId);
        Task AddAsync(ProductRating rating);
    }
}
