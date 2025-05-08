using Application.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VnPayController : ControllerBase
    {
        private readonly IVnPayService _vnPayService;
        public VnPayController(IVnPayService vnPayService)
        {
            _vnPayService = vnPayService;
        }

        [HttpGet]
        public IActionResult CreatePaymentUrl(long amount)
        {
            string paymentUrl = _vnPayService.CreatePaymentUrl(HttpContext, Convert.ToInt64(amount));
            return Ok(paymentUrl);
        }
    }
}
