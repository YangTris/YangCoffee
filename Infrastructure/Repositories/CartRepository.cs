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
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;

        public CartRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateCartAsync(Cart cart)
        {
            if (cart == null) throw new ArgumentNullException(nameof(cart));
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCartAsync(string id)
        {
            var cart = await _context.Carts.FindAsync(id);
            if (cart == null) throw new KeyNotFoundException($"Cart with ID {id} not found.");
            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();
        }

        public async Task<Cart> GetCartByIdAsync(string id)
        {
            return await _context.Carts
                .Include(c => c.CartItems)
                    .ThenInclude(ci => ci.ProductVariant)
                    .ThenInclude(pv => pv.Product)
                    .ThenInclude(pv => pv.ProductImages)
                .FirstOrDefaultAsync(c => c.UserId == id);
        }
    }
}
