using System;
using System.Collections.Generic;

namespace FoodApp.Domain.Entities
{
    public class Product : Entity<Guid>
    {
        public Product()
        {
            this.Tags = new HashSet<string>();
        }
        public Product(string name) : base(Guid.NewGuid())
        {
            this.Name = name;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<string> Tags { get; set; }
    }
}
