using FoodApp.Application.Interfaces;
using FoodApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FoodApp.Application.Stores.Queries
{
    public class GetStoresQueryHandler : IRequestHandler<GetStoresQuery, IEnumerable<StoreDto>>
    {
        public GetStoresQueryHandler(IRepository<Store, Guid> repository)
        {
            this.Repository = repository;
        }
        private IRepository<Store, Guid> Repository { get; }
        public async Task<IEnumerable<StoreDto>> Handle(GetStoresQuery request, CancellationToken cancellationToken)
        {
            ICollection<StoreDto> result = new HashSet<StoreDto>();

            if (request.GetAll)
            {
                var stores = await Repository.GetAllAsync();
                foreach (var store in stores)
                {
                    result.Add(new StoreDto(store));
                }
                return result;
            }
            var storesByName = await Repository.FindAsync(s => s.Name.Equals(request.Name));
            foreach (var store in storesByName)
            {
                result.Add(new StoreDto(store));
            }
            return result;
        }
    }
}
