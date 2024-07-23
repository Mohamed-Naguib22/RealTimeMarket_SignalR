using MediatR;
using RealTimeUsingSockets.Application.Interfaces;
using RealTimeUsingSockets.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeUsingSockets.Application.Features.ProductFeatures.Buy
{
    public class BuyProductHandler : IRequestHandler<BuyProductCommand, Product>
    {
        private readonly IUnitOfWork _unitOfWork;
        public BuyProductHandler(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> Handle(BuyProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Products.GetProductByIdAsync(request.ProductId);

            if (product == null || product.NumberOfItemsInStock <= 0)
                return null;

            product.NumberOfSales++;
            product.NumberOfItemsInStock--;

            await _unitOfWork.CompleteAsync();
            return product;
        }
    }
}
