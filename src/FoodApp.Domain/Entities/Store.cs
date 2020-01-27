using System;
using System.Collections.Generic;

namespace FoodApp.Domain.Entities
{
    public class Store : Entity<Guid>
    {
        public Store(string name) : base(Guid.NewGuid())
        {
            this.Name = name;
        }
        public Store(string name, string address) : this(name)
        {
            this.Address = address;
        }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
