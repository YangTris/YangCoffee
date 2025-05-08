using System.Diagnostics;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using Shared.DTOs;

namespace MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly HttpClient _httpClient;
        public OrderController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }
        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            var userId = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            var cartResponse = await _httpClient.GetAsync($"api/Carts?userId={userId}");

            var cart = await cartResponse.Content.ReadFromJsonAsync<CartDTO>();
            var orderDTO = new OrderDTO
            {
                OrderId = Guid.NewGuid().ToString(),
                UserId = userId,
                OrderDate = DateTime.UtcNow,
                OrderStatus = "Pending",
                TotalAmount = cart.CartItems.Sum(item => item.Price * item.Quantity),
                OrderDetails = cart.CartItems.Select(item => new OrderDetailDTO
                {
                    ProductVariantId = item.ProductVariantId,
                    ProductName = item.ProductName,
                    Quantity = item.Quantity,
                    Price = item.Price
                }).ToList()
            };

            return View(orderDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(OrderDTO orderDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userId = HttpContext.Session.GetString("UserId");

            var cartResponse = await _httpClient.GetAsync($"api/Carts?userId={userId}");
            var cart = await cartResponse.Content.ReadFromJsonAsync<CartDTO>();

            orderDTO.OrderId = Guid.NewGuid().ToString();
            orderDTO.UserId = userId;
            orderDTO.OrderDate = DateTime.UtcNow;
            orderDTO.OrderStatus = "Success";
            orderDTO.TotalAmount = orderDTO.OrderDetails.Sum(item => item.Price * item.Quantity);
            orderDTO.OrderDetails = cart.CartItems.Select(item => new OrderDetailDTO
            {
                OrderDetailId = Guid.NewGuid().ToString(),
                ProductVariantId = item.ProductVariantId,
                ProductName = item.ProductName,
                Size = item.Size,
                SubTotal = item.Price * item.Quantity,
                ProductImageUrl = item.ImageUrl,
                OrderId = orderDTO.OrderId,
                Quantity = item.Quantity,
                Price = item.Price
            }).ToList();

            var response = await _httpClient.PostAsJsonAsync("api/Orders", orderDTO);

            if (response.IsSuccessStatusCode)
            {
                var amount = (int)orderDTO.OrderDetails.Sum(item => item.Price * item.Quantity);
                Console.WriteLine($"Order created successfully. Order ID: {orderDTO.OrderId}, Amount: {amount}");
                var paymentResponse = await _httpClient.GetAsync($"api/VnPay?amount={amount}");
                if (paymentResponse.IsSuccessStatusCode)
                {
                    var paymentUrl = await paymentResponse.Content.ReadAsStringAsync();
                    return Redirect(paymentUrl);
                }
                return RedirectToAction("ThankYou");
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error: {response.StatusCode}, Body: {errorContent}");
            }

            return View(orderDTO);
        }

        [HttpGet]
        public IActionResult ThankYou()
        {
            return View();
        }
    }
}
