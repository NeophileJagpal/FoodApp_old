using FoodApp.Application.Interfaces;
using FoodApp.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FoodApp.Application.Products.Commands.Create
{
    public class CreateProductCommandHandlers : IRequestHandler<CreateProductCommand, Guid>
    {
        public CreateProductCommandHandlers(IRepository<Product, Guid> productRepository, IRepository<StoreProduct, Guid> storeProductRepository)
        {
            this.ProductRepository = productRepository;
            this.StoreProductRepository = storeProductRepository;
        }
        private IRepository<StoreProduct, Guid> StoreProductRepository { get; }
        private IRepository<Product, Guid> ProductRepository { get; }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = request.GetProduct();
            await this.ProductRepository.AddAsync(product);
            await this.StoreProductRepository.AddAsync(new StoreProduct(request.StoreId, product.Id)
            {
                Price = request.Price,
                DiscountRate = request.DiscountRate,
                AvailableCustomizations = request.AvailableCustomizations,
                CreatedBy = request.ActionBy
            });
            return product.Id;
        }
    }
}
