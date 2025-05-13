using System.Net;
using System.Text;
using System.Text.Json;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        public async Task<IActionResult> ProductList(ProductQuery productQuery)
        {
            try
            {
                var categories = await _httpClient.GetFromJsonAsync<List<CategoryDTO>>("api/categories");

                ViewData["selectedCategoryIds"] = productQuery.CategoryId ?? Array.Empty<string>();
                ViewData["allCategories"] = categories;
                ViewData["sortBy"] = productQuery.SortBy ?? "";

                var baseQuery = new Dictionary<string, string?>
                {
                    ["SortBy"] = productQuery.SortBy,
                    ["PageNumber"] = productQuery.PageNumber.ToString(),
                    ["PageSize"] = productQuery.PageSize.ToString()
                };

                var queryParts = baseQuery
                    .Where(kvp => !string.IsNullOrEmpty(kvp.Value))
                    .Select(kvp => $"{kvp.Key}={Uri.EscapeDataString(kvp.Value!)}")
                    .ToList();

                // Add each CategoryId separately
                if (productQuery.CategoryId != null)
                {
                    foreach (var catId in productQuery.CategoryId)
                    {
                        queryParts.Add($"CategoryId={Uri.EscapeDataString(catId)}");
                    }
                }

                var queryString = string.Join("&", queryParts);
                var url = $"api/Products/query?{queryString}";
                var response = await _httpClient.GetFromJsonAsync<PaginatedResult<ProductDTO>>(url);

                if (response == null)
                {
                    return View("Error", "No products found.");
                }

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

                var ratings = await _httpClient.GetFromJsonAsync<List<ProductRatingDTO>>($"api/ProductRatings?quantity=3&productId={id}");
                product.ProductRatings = ratings ?? new List<ProductRatingDTO>();

                return View(product);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> RatingProduct(ProductRatingDTO ratingDto)
        {
            var userId = HttpContext.Session.GetString("UserId");
            var userName = HttpContext.Session.GetString("UserName");
            if (userId == null || userName == null)
            {
                TempData["Error"] = "You must be logged in to rate a product.";
                return RedirectToAction("Login", "Account");
            }

            ratingDto.UserId = userId;
            ratingDto.UserName = userName;

            Console.WriteLine($"UserId: {ratingDto.UserId}");
            Console.WriteLine($"ProductId: {ratingDto.ProductId}");
            Console.WriteLine($"Rating: {ratingDto.Rating}");
            Console.WriteLine($"Comment: {ratingDto.Comment}");

            var json = JsonConvert.SerializeObject(ratingDto);
            Console.WriteLine($"JSON: {json}");
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/ProductRatings", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductDetail", "Product", new { id = ratingDto.ProductId });
            }
            else if (response.StatusCode == HttpStatusCode.Conflict)
            {
                TempData["Error"] = "You have already rated this product.";
            }
            else
            {
                TempData["Error"] = "Failed to submit rating.";
            }

            return RedirectToAction("ProductDetail", "Product", new { id = ratingDto.ProductId });
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
