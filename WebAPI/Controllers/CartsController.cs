using Application.IServices;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCart(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("User ID cannot be null or empty.");
            }
            var cart = await _cartService.CreateCartAsync(userId);
            return CreatedAtAction(nameof(GetCartById), new { userId = cart.UserId }, cart);
        }

        [HttpGet]
        [ProducesResponseType<CategoryDTO>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CartDTO>> GetCartById(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("User ID cannot be null or empty.");
            }
            var cart = await _cartService.GetCartByIdAsync(userId);
            if (cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }

        [HttpDelete("{userId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteCart(string userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var cart = await _cartService.GetCartByIdAsync(userId);
            if (cart == null)
            {
                return NotFound("Cart not found.");
            }
            await _cartService.DeleteCartAsync(userId);
            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddItem(string userId, string productVariantId, int quantity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _cartService.AddItemAsync(userId, productVariantId, quantity);
            return CreatedAtAction(nameof(GetCartById), new { userId }, null);
        }

        [HttpGet("{cartItemId}")]
        [ProducesResponseType<CategoryDTO>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CartItemDTO>> GetCartItemById(string userId, string cartItemId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var cart = await _cartService.GetCartByIdAsync(userId);
            if (cart == null)
            {
                return NotFound();
            }
            var cartItem = await _cartService.GetCartItemAsync(userId, cartItemId);
            if(cartItem == null)
            {
                return NotFound();
            }
            return Ok(cartItem);
        }

        [HttpDelete("{userId}/{cartItemId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RemoveItem(string userId, string cartItemId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var cart = await _cartService.GetCartByIdAsync(userId);
            if (cart == null)
            {
                return NotFound("Cart not found.");
            }

            var cartItem = await _cartService.GetCartItemAsync(userId, cartItemId);
            if (cartItem == null)
            {
                return NotFound("Item not found in the cart.");
            }

            await _cartService.RemoveItemAsync(userId, cartItemId);
            return NoContent();
        }
    }
}
