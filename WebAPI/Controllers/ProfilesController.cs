using Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController (UserManager<User> userManager) : ControllerBase
    {
        private UserManager<User> _userManager = userManager;

        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {
            var result = await HttpContext.AuthenticateAsync();
                     
            if (result.Succeeded)
            {
                var user = await _userManager.GetUserAsync(result.Principal);
                return Ok(user);
            }
            return Forbid();
        }
    }
}
