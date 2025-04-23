using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Shared.DTOs;

namespace Application.IServices
{
    public interface ICartService
    {
        Task<CartDTO> CreateCartAsync(string userId);
        Task DeleteCartAsync(string userId);
        Task<CartDTO> GetCartByIdAsync(string userId);
        Task AddItemAsync(string userId, string productVariantId, int quantity);
        Task RemoveItemAsync(string userId, string productId);
        Task<CartItemDTO> GetCartItemAsync(string userId, string productId);
    }
}
