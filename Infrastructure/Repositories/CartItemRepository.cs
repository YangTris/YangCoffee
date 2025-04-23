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
    public class CartItemRepository : ICartItemRepository
    {
        private readonly ApplicationDbContext _context;

        public CartItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddItemAsync(CartItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            _context.CartItems.Add(item);
            await _context.SaveChangesAsync();
        }

        public Task<CartItem> GetCartItemByIdAsync(string id)
        {
            return _context.CartItems
                .Include(ci => ci.ProductVariant)
                    .ThenInclude(pv => pv.Product)
                    .ThenInclude(p => p.ProductImages)
                .FirstOrDefaultAsync(ci => ci.CartItemId == id);
        }

        //public async Task<CartItem> GetAllCartItemAsync(string cartId)
        //{
        //    return await _context.CartItems
        //        .Include(ci => ci.ProductVariant)
        //        .FirstOrDefaultAsync(ci => ci.CartId == cartId);
        //}

        public async Task RemoveItemAsync(string id)
        {
            var item = await _context.CartItems.FindAsync(id);
            if (item == null) throw new KeyNotFoundException($"CartItem with ID {id} not found.");
            _context.CartItems.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CartItem cartItem)
        {
            if (cartItem == null) throw new ArgumentNullException(nameof(cartItem));
            _context.CartItems.Update(cartItem);
            await _context.SaveChangesAsync();
        }
    }
}
