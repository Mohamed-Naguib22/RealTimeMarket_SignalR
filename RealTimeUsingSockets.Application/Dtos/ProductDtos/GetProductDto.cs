using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeUsingSockets.Application.Dtos.ProductDtos
{
    public class GetProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int NumberOfItemsInStock { get; set; }
        public int NumberOfSales { get; set; }
    }
}
