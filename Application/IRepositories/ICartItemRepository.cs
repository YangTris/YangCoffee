using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Application.IRepositories
{
    public interface ICartItemRepository
    {
        //Task<CartItem> GetAllCartItemAsync(string cartId);
        Task<CartItem> GetCartItemByIdAsync(string id);
        Task AddItemAsync(CartItem item);
        Task UpdateAsync(CartItem cartItem);
        Task RemoveItemAsync(string id);
    }
}
