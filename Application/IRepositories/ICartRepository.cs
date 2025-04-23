using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Application.IRepositories
{
    public interface ICartRepository
    {
        Task<Cart> GetCartByIdAsync(string id);
        Task CreateCartAsync(Cart cart);
        Task DeleteCartAsync(string id);
    }
}
