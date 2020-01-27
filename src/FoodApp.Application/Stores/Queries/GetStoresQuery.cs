using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodApp.Application.Stores.Queries
{
    public class GetStoresQuery : IRequest<IEnumerable<StoreDto>>
    {
        public bool GetAll { get; set; }
        public string Name { get; set; }
    }
}
