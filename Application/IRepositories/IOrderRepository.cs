using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Application.IRepositories
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderByIdAsync(string id);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task CreateOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
        Task DeleteCartAsync(string id);
    }
}
