using System.Text.Json;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient _httpClient;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var products = await _httpClient.GetFromJsonAsync<List<ProductDTO>>("api/products");
                return View(products);
            }
            catch (Exception ex)
            {
                // Handle error (e.g., log it)
                return View("Error", ex.Message);
            }
        }
        public async Task<IActionResult> ProductList()
        {
            try
            {
                var products = await _httpClient.GetFromJsonAsync<List<ProductDTO>>("api/products");
                return View(products);
            }
            catch (Exception ex)
            {
                // Handle error (e.g., log it)
                return View("Error", ex.Message);
            }
        }

        public async Task<IActionResult> ProductDetail(string id)
        {
            try
            {
                var product = await _httpClient.GetFromJsonAsync<ProductDTO>($"api/products/{id}");
                if (product == null)
                {
                    return NotFound();
                }
                return View(product);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }
    }
}
