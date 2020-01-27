using FoodApp.Application.Common.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;

namespace FoodApp.Application.Products.Queries
{
    public class GetProductQuery : IRequest<IEnumerable<ProductDto>>
    {
        public string Name { get; set; }
        public Guid StoreId { get; set; }
    }
}
