using FoodApp.Application.Interfaces;
using FoodApp.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FoodApp.Application.Stores.Commands.Create
{
    public class CreateStoreCommandHandlers : IRequestHandler<CreateStoreCommand, Guid>
    {
        public CreateStoreCommandHandlers(IRepository<Store, Guid> repository)
        {
            this.Repository = repository;
        }
        private IRepository<Store, Guid> Repository { get; }

        public async Task<Guid> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
        {
            var store = new Store(request.Name, request.Address)
            {
                CreatedBy = request.ActionBy
            };
            await this.Repository.AddAsync(store);
            return store.Id;
        }
    }
}
