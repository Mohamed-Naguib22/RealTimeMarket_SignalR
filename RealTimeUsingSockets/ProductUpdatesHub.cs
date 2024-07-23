using Microsoft.AspNetCore.SignalR;
using RealTimeUsingSockets.Application.Interfaces;
using RealTimeUsingSockets.Domain.Models;

namespace RealTimeUsingSockets
{
    public class ProductUpdatesHub : Hub
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductUpdatesHub(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddProduct(Product product)
        {
            await Clients.All.SendAsync("AddProduct", product);
        }
        public async Task DeleteProduct(int productId)
        {
            await Clients.All.SendAsync("DeleteProduct", productId);
        }
        public async Task BuyProduct(Product product)
        {
            await Clients.All.SendAsync("BuyProduct", product);
        }
        public async Task MostSoldProduct(Product mostSoldProduct)
        {
            await Clients.All.SendAsync("MostSoldProduct", mostSoldProduct);
        }
    }
}
