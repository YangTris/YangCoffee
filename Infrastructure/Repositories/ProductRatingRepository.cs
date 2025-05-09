using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IRepositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductRatingRepository : IProductRatingRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRatingRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ProductRating> GetUserRatingForProductAsync(string userId, string productId)
        {
            return await _context.ProductRatings.FirstOrDefaultAsync(r => r.UserId == userId && r.ProductId == productId);

        }
        public async Task AddAsync(ProductRating rating)
        {
            _context.ProductRatings.Add(rating);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductRating>> GetRatingByQuantity(int quantity, string productId)
        {
            return await _context.ProductRatings
                .Include(r => r.User)
                .Where(r => r.ProductId == productId)
                .OrderByDescending(r => r.CreatedDate)
                .Take(quantity)
                .ToListAsync();
        }
    }
}
