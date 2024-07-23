using MediatR;
using RealTimeUsingSockets.Application.Dtos.ProductDtos;
using RealTimeUsingSockets.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeUsingSockets.Application.Features.ProductFeatures.Add
{
    public class AddProductCommand : IRequest<Product>
    {
        public AddProductDto AddProductDto { get; }
        public AddProductCommand(AddProductDto addProductDto)
        {
            AddProductDto = addProductDto;
        }
    }
}
