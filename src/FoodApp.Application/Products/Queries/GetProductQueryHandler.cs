using FoodApp.Application.Common.ViewModels;
using FoodApp.Application.Interfaces;
using FoodApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FoodApp.Application.Products.Queries
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, IEnumerable<ProductDto>>
    {
        public GetProductQueryHandler(IRepository<Product, Guid> productRepository, IRepository<StoreProduct, Guid> storeProductRepository)
        {
            this.ProductRepository = productRepository;
            this.StoreProductRepository = storeProductRepository;
        }
        private IRepository<Product, Guid> ProductRepository { get; }
        private IRepository<StoreProduct, Guid> StoreProductRepository { get; }
        public async Task<IEnumerable<ProductDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            ICollection<ProductDto> result = new HashSet<ProductDto>();
            if (request.StoreId == Guid.Empty)
                throw new ArgumentNullException(nameof(request.StoreId));

            var storeProducts = await this.StoreProductRepository.FindAsync(sp => sp.StoreId.Equals(request.StoreId));
            var products = await this.ProductRepository.FindAsync(p => storeProducts.Any(sp => sp.ProductId.Equals(p.Id)));
            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                products = products.Where(p => p.Name.Equals(request.Name));
            }
            foreach (var product in products)
            {
                var sp = storeProducts.Where(sp => sp.ProductId.Equals(product.Id)).FirstOrDefault();
                result.Add(new ProductDto(product, sp));
            }
            return result;
        }
    }
}
