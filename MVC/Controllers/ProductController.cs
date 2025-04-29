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
        public async Task<IActionResult> ProductList(
            string? searchName,
            string? sortBy,
            bool isDescending = false,
            int pageNumber = 1,
            int pageSize = 3,
            decimal? price = null,
            string[]? size = null,
            string[]? region = null)
        {
            try
            {
                ViewData["sortBy"] = sortBy ?? "createddate"; // Default to createddate if null
                ViewData["isDescending"] = isDescending.ToString().ToLower();
                ViewData["searchName"] = searchName;
                ViewData["price"] = price?.ToString();
                ViewData["size"] = size?.ToString();
                ViewData["region"] = region;
                // Build the query string for the WebAPI
                var query = new Dictionary<string, string>
                {
                    { "searchName", searchName },
                    { "sortBy", sortBy },
                    { "isDescending", isDescending.ToString() },
                    { "pageNumber", pageNumber.ToString() },
                    { "pageSize", pageSize.ToString() }
                };

                var queryString = string.Join("&", query
                    .Where(kvp => !string.IsNullOrEmpty(kvp.Value))
                    .Select(kvp => $"{kvp.Key}={Uri.EscapeDataString(kvp.Value)}"));

                var url = $"api/Products/search?{queryString}";
                var response = await _httpClient.GetFromJsonAsync<PaginatedResult<ProductDTO>>(url);

                if (response == null)
                {
                    return View("Error", "No products found.");
                }

                // Pass the paginated result to the view
                return View(response);
            }
            catch (Exception ex)
            {
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

    public class PaginatedResult<T>
    {
        public int TotalItems { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
