using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Supabase.Gotrue;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController (ILogger<ProfilesController> logger, UserManager<IdentityUser> userManager) : ControllerBase
    {
        private ILogger<ProfilesController> _logger = logger;
        private UserManager<IdentityUser> _userManager = userManager;

        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {
            var result = await HttpContext.AuthenticateAsync();
            
            _logger.LogError(">>>>>>>>>>>>>>>>", result.Succeeded);
            
            if (result.Succeeded)
            {
                var user = await _userManager.GetUserAsync(result.Principal);
                return Ok(user);
            }
            return Forbid();
        }
    }
}
