using MediatR;
using System;
using System.Collections.Generic;

namespace FoodApp.Application.Combos.Queries
{
    public class GetComboQuery : IRequest<IEnumerable<ComboDto>>
    {
        public string Name { get; set; }
        public Guid StoreId { get; set; }
    }
}
