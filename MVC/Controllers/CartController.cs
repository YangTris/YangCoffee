using System.Net.Http.Headers;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace MVC.Controllers
{
    public class CartController : Controller
    {
        private readonly HttpClient _httpClient;
        public CartController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }

        [HttpGet]
        public async Task<IActionResult> AddToCart()
        {
            var userId = HttpContext.Session.GetString("UserId");

            var cartResponse = await _httpClient.GetAsync($"api/Carts?userId={userId}");

            if (!cartResponse.IsSuccessStatusCode)
            {
                return View("Error");
            }

            var cart = await cartResponse.Content.ReadFromJsonAsync<CartDTO>();

            return View(cart);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(string productVariantId, int quantity)
        {
            var userId = HttpContext.Session.GetString("UserId");
            
            var postUrl = $"/api/Carts?userId={userId}&productVariantId={productVariantId}&quantity={quantity}";
            
            var addItemResponse = await _httpClient.PostAsync(postUrl, null);

            if (addItemResponse.IsSuccessStatusCode)
            {
                Console.WriteLine("Item added to cart successfully.");
            }

            var getCartResponse = await _httpClient.GetAsync($"/api/Carts/?userId={userId}");

            CartDTO cart = new CartDTO();

            if (getCartResponse.IsSuccessStatusCode)
            {
                cart = await getCartResponse.Content.ReadFromJsonAsync<CartDTO>();
            }

            return View(cart);
        }
    }
}
