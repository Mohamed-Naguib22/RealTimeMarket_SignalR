using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeUsingSockets.Application.Features.ProductFeatures.Delete
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public int ProductId { get; }
        public DeleteProductCommand(int productId) 
        {
            ProductId = productId;
        }
    }
}
