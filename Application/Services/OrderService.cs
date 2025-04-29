using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IRepositories;
using Application.IServices;
using Domain;
using Domain.Enum;
using Shared.DTOs;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly ICartRepository _cartRepository;
        public OrderService(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, ICartRepository cartRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _cartRepository = cartRepository;
        }

        private static OrderDTO MapToDTO(Order order)
        {
            if (order == null)
            {
                return null;
            }
            return new OrderDTO
            {
                OrderId = order.OrderId,
                UserId = order.UserId,
                PhoneNumber = order.PhoneNumber,
                ShippingAddress = order.ShippingAddress,
                TotalAmount = order.TotalAmount,
                OrderDate = order.OrderDate,
                OrderStatus = order.OrderStatus.ToString(),
                OrderDetails = order.OrderDetails.Select(od => new OrderDetailDTO
                {
                    ProductVariantId = od.ProductVariantId,
                    OrderId = order.OrderId,
                    ProductName = od.ProductVariant.Product.Name,
                    ProductImageUrl = od.ProductVariant.Product.ProductImages.FirstOrDefault().ImageUrl,
                    Size = od.ProductVariant.Size.ToString(),
                    SubTotal = od.SubTotal,
                    OrderDetailId = od.OrderDetailId,
                    Quantity = od.Quantity,
                    Price = od.Price
                }).ToList()
            };
        }

        public async Task<OrderDTO> CreateOrderAsync(string userId, string shippingAddress, string phoneNumber)
        {
            var cart = await _cartRepository.GetCartByIdAsync(userId);
            if (cart == null || cart.CartItems.Count == 0)
            {
                throw new Exception("Cart is empty or does not exist.");
            }
            var order = new Order
            {
                OrderId = Guid.NewGuid().ToString(),
                UserId = userId,
                TotalAmount = cart.CartItems.Sum(ci => ci.Quantity * ci.Price),
                OrderDate = DateTimeOffset.Now,
                OrderStatus = OrderStatus.Processing,
                ShippingAddress = shippingAddress,
                PhoneNumber = phoneNumber
            };

            await _orderRepository.CreateOrderAsync(order);
            
            foreach (var item in cart.CartItems)
            {
                var orderDetail = new OrderDetail
                {
                    OrderDetailId = Guid.NewGuid().ToString(),
                    OrderId = order.OrderId,
                    ProductVariantId = item.ProductVariantId,
                    Quantity = item.Quantity,
                    Price = item.Price,
                    SubTotal = item.Quantity * item.Price
                };
                await _orderDetailRepository.AddOrderDetailAsync(orderDetail);
            }
            await _cartRepository.DeleteCartAsync(userId);
            return MapToDTO(order);
        }

        public async Task<IEnumerable<OrderDTO>> GetAllOrdersAsync()
        {
            var orderList = await _orderRepository.GetAllOrdersAsync();
            return orderList.Select(MapToDTO);
        }

        public async Task<OrderDTO> GetOrderByIdAsync(string id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            return MapToDTO(order);
        }
    }
}
