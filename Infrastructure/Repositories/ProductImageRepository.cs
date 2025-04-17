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
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductImageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddProductImageAsync(ProductImage productImage)
        {
            _context.ProductImages.Add(productImage);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductImageAsync(int id)
        {
            var productImage = _context.ProductImages.Find(id);
            if(productImage != null)
            {
                _context.ProductImages.Remove(productImage);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ProductImage>> GetAllProductImagesAsync(string producVarianttId)
        {
            return await _context.ProductImages
                .Where(pi => pi.ProductVariantId == producVarianttId)
                .ToListAsync();
        }
    }
}
