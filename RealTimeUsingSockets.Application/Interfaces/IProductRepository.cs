using RealTimeUsingSockets.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeUsingSockets.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> AddProductAsync(Product product);
        Task<Product> GetProductByIdAsync(int productId);
        Task<Product> GetMostSoldProductAsync();
        void DeleteProductAsync(Product product);
    }
}
