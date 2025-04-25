using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IRepositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductVariantRepository : IProductVariantRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductVariantRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddProductVariantAsync(ProductVariant productVariant)
        {
            _context.ProductVariants.Add(productVariant);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductVariantAsync(string id)
        {
            var productVariant = _context.ProductVariants.Find(id);
            if (productVariant != null)
            {
                _context.ProductVariants.Remove(productVariant);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ProductVariant>> GetAllVariantByProductIdAsync(string productId)
        {
            return await _context.ProductVariants
                .Where(pv => pv.ProductId == productId)
                .ToListAsync();
        }

        public async Task<ProductVariant> GetVariantByIdAsync(string id)
        {
            return await _context.ProductVariants
                .FirstOrDefaultAsync(p => p.ProductVariantId == id);
        }

        public Task UpdateProductVariantAsync(ProductVariant productVariant)
        {
            _context.ProductVariants.Update(productVariant);
            return _context.SaveChangesAsync();
        }
    }
}
