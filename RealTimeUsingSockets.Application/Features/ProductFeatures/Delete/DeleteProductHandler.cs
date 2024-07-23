using MediatR;
using RealTimeUsingSockets.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeUsingSockets.Application.Features.ProductFeatures.Delete
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteProductHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Products.GetProductByIdAsync(request.ProductId);

            if (product == null)
                return false;

            _unitOfWork.Products.DeleteProductAsync(product);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
