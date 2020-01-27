using MediatR;
using System;

namespace FoodApp.Application.Stores.Commands.Create
{
    public class CreateStoreCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string ActionBy { get; set; }
    }
}
