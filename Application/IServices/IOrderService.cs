using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTOs;

namespace Application.IServices
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDTO>> GetAllOrdersAsync();
        Task<OrderDTO> GetOrderByIdAsync(string id);
        Task<OrderDTO> CreateOrderAsync(string userId, string shippingAddress, string phoneNumber);
        //Task CreateOrderAsync(OrderDTO orderDTO, CartDTO cartDTO);
        //Task<OrderDTO> GetOrderByIdAsync(string id);
        //Task UpdateOrderAsync(string id, OrderDTO orderDTO);
        //Task DeleteOrderAsync(string id);
        //Task<IEnumerable<OrderDTO>> GetOrdersByUserIdAsync(string userId);
    }
}
