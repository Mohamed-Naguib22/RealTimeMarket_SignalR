using MediatR;
using RealTimeUsingSockets.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeUsingSockets.Application.Features.ProductFeatures.Buy
{
    public class BuyProductCommand : IRequest<Product>
    {
        public int ProductId { get; }
        public BuyProductCommand(int productId) 
        {
            ProductId = productId;
        }
    }
}
