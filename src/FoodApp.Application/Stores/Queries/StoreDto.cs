using FoodApp.Domain.Entities;
using System;

namespace FoodApp.Application.Stores.Queries
{
    public class StoreDto
    {
        public StoreDto()
        {

        }
        public StoreDto(Store store)
        {
            this.Id = store.Id;
            this.Name = store.Name;
            this.Address = store.Address;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
