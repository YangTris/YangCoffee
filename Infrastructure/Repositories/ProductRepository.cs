﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IRepositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task AddProductAsync(Product product)
        {
            _context.Products.Add(product);
            return _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(string id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products
                .Include(p => p.ProductVariants)
                .ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(string id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
