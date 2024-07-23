using AutoMapper;
using MediatR;
using RealTimeUsingSockets.Application.Dtos.ProductDtos;
using RealTimeUsingSockets.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeUsingSockets.Application.Features.ProductFeatures.GetAll
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<GetProductDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllProductsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<GetProductDto>>(await _unitOfWork.Products.GetAllProductsAsync());
        }
    }
}
