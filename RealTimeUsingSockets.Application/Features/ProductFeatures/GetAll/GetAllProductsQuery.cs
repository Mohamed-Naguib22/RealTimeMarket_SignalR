using MediatR;
using RealTimeUsingSockets.Application.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeUsingSockets.Application.Features.ProductFeatures.GetAll
{
    public class GetAllProductsQuery : IRequest<IEnumerable<GetProductDto>>
    {
    }
}
