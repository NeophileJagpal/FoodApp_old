using System;

namespace FoodApp.Domain.Entities
{
    public class Combo : Entity<Guid>
    {
        public Combo()
        {
        }
        public Combo(string name) : base(Guid.NewGuid())
        {
            this.Name = name;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
