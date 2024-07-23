using AutoMapper;
using MediatR;
using RealTimeUsingSockets.Application.Dtos;
using RealTimeUsingSockets.Application.Features.ProductFeatures.GetAll;
using RealTimeUsingSockets.Application.Interfaces;
using RealTimeUsingSockets.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeUsingSockets.Application.Features.ProductFeatures.Add
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, Product>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AddProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Products.AddProductAsync(_mapper.Map<Product>(request.AddProductDto));
            await _unitOfWork.CompleteAsync();
            return product;
        }
    }
}
