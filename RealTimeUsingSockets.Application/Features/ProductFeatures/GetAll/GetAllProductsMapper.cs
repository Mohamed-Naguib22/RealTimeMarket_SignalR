using AutoMapper;
using RealTimeUsingSockets.Application.Dtos.ProductDtos;
using RealTimeUsingSockets.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeUsingSockets.Application.Features.ProductFeatures.GetAll
{
    public class GetAllProductsMapper : Profile
    {
        public GetAllProductsMapper()
        {
            CreateMap<Product, GetProductDto>();
        }
    }
}
