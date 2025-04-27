using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IRepositories;
using Application.IServices;
using Domain;
using Shared.DTOs;

namespace Application.Services
{
    public class CartService : ICartService
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IProductVariantRepository _productVariantRepository;

        public CartService(ICartItemRepository cartItemRepository,
            ICartRepository cartRepository,
            IProductVariantRepository productVariantRepository)
        {
            _cartItemRepository = cartItemRepository;
            _cartRepository = cartRepository;
            _productVariantRepository = productVariantRepository;
        }

        private static CartDTO MapToDTO(Cart cart)
        {
            if (cart == null) return null;

            return new CartDTO
            {
                UserId = cart.UserId,
                CartItems = cart.CartItems?.Select(ci => new CartItemDTO
                {
                    CartItemId = ci.CartItemId,
                    ProductName = ci.ProductVariant.Product.Name,
                    Price = ci.ProductVariant.Price,
                    Size = ci.ProductVariant.Size.ToString(),
                    Quantity = ci.Quantity,
                    ImageUrl = ci.ProductVariant.Product.ProductImages?.FirstOrDefault().ImageUrl,
                    ProductVariantId = ci.ProductVariantId
                }).ToList()
            };
        }

        private static CartItemDTO MapToCartItemDTO(CartItem cartItem)
        {
            if (cartItem == null) return null;
            return new CartItemDTO
            {
                CartItemId = cartItem.CartItemId,
                Quantity = cartItem.Quantity,
                Price = cartItem.Price,
                ProductName = cartItem.ProductVariant.Product.Name,
                ImageUrl = cartItem.ProductVariant.Product.ProductImages.FirstOrDefault().ImageUrl,
                Size = cartItem.ProductVariant.Size.ToString(),
                ProductVariantId = cartItem.ProductVariantId
            };
        }
        public async Task<CartDTO> CreateCartAsync(string userId)
        {
            var cart = new Cart
            {
                UserId = userId,
                CartItems = new List<CartItem>()
            };

            await _cartRepository.CreateCartAsync(cart);
            return MapToDTO(cart);
        }

        public async Task DeleteCartAsync(string id)
        {
            var cart = await _cartRepository.GetCartByIdAsync(id);
            if (cart != null)
            {
                if (cart.CartItems != null && cart.CartItems.Any())
                {
                    var cartItemIds = cart.CartItems.Select(ci => ci.CartItemId).ToList();
                    foreach (var item in cartItemIds)
                    {
                        await _cartItemRepository.RemoveItemAsync(item);
                    }
                }
                await _cartRepository.DeleteCartAsync(id);
            }
        }

        public async Task<CartDTO> GetCartByIdAsync(string cartId)
        {
            var cart = await _cartRepository.GetCartByIdAsync(cartId);
            return MapToDTO(cart);
        }

        public async Task AddItemAsync(string userId, string productVariantId, int quantity)
        {
            var cart = await _cartRepository.GetCartByIdAsync(userId);
            if (cart == null)
            {
                var newCart = new Cart
                {
                    UserId = userId,
                    CartItems = new List<CartItem>()
                };
                await _cartRepository.CreateCartAsync(newCart);
                cart = newCart;
            }

            if(cart.CartItems != null)
            {             
                foreach (var item in cart.CartItems)
                {
                    if (item.ProductVariantId == productVariantId)
                    {
                        item.Quantity += quantity;
                        await _cartItemRepository.UpdateAsync(item);
                        return;
                    }
                }
            }

            var productVariant = await _productVariantRepository.GetVariantByIdAsync(productVariantId);
            var cartItem = new CartItem
            {
                CartItemId = Guid.NewGuid().ToString(),
                ProductVariantId = productVariantId,
                Quantity = quantity,
                Price = productVariant.Price,
                CartId = userId,
            };
            await _cartItemRepository.AddItemAsync(cartItem);
        }
        public async Task RemoveItemAsync(string cartId, string id)
        {
            var cart = await _cartRepository.GetCartByIdAsync(cartId);
            if (cart != null)
            {
                var cartItem = await _cartItemRepository.GetCartItemByIdAsync(id);
                if (cartItem != null && cartItem.CartItemId == id)
                {
                    await _cartItemRepository.RemoveItemAsync(id);
                }
            }
        }

        public async Task<CartItemDTO> GetCartItemAsync(string userId, string cartItemId)
        {
            var cart = await _cartRepository.GetCartByIdAsync(userId);
            if (cart != null)
            {
                var cartItem = await _cartItemRepository.GetCartItemByIdAsync(cartItemId);
                return MapToCartItemDTO(cartItem);
            }
            return null;
        }
    }
}
