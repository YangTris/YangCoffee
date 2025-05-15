using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using NuGet.Common;
using Shared.DTOs;

namespace MVC.Controllers
{
    class User
    {
        public Guid id { get; set; }
        public string userName { get; set; }
    }
    class Token
    {
        public string accessToken { get; set; }
        public string tokenType { get; set; }
        public int expiresIn { get; set; }
        public string refreshToken { get; set; }
    }


    public class AccountController : Controller
    {
        private readonly HttpClient _httpClient;

        public AccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(loginDTO);
            }

            var response = await _httpClient.PostAsJsonAsync("/login", loginDTO);

            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadFromJsonAsync<Token>();
                HttpContext.Session.SetString("AuthToken", body.accessToken);

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", body.accessToken);
                var AuthResponse = await _httpClient.GetAsync("/api/Profiles");

                if (AuthResponse.IsSuccessStatusCode)
                {
                    var responseContent = await AuthResponse.Content.ReadFromJsonAsync<User>();
                    HttpContext.Session.SetString("UserId", responseContent.id.ToString());
                    HttpContext.Session.SetString("UserName", responseContent.userName.ToString());
                }

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(loginDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(registerDTO);
            }

            var response = await _httpClient.PostAsJsonAsync("/api/Auth/register", registerDTO);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Login");
            }

            ModelState.AddModelError(string.Empty, "Registration failed.");
            return View(registerDTO);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("AuthToken");
            HttpContext.Session.Remove("UserId");
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}