using Microsoft.EntityFrameworkCore;
using RealTimeUsingSockets.Application.Interfaces;
using RealTimeUsingSockets.Domain.Models;
using RealTimeUsingSockets.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeUsingSockets.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        protected ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<Product> AddProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            return product;
        }
        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
        }
        public void DeleteProductAsync(Product product)
        {
            _context.Products.Remove(product);
        }
        public async Task<Product> GetMostSoldProductAsync()
        {
            return await _context.Products.OrderByDescending(p => p.NumberOfSales)
                .FirstOrDefaultAsync();
        }
    }
}
