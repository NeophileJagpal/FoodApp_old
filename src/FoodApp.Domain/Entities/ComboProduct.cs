using System;

namespace FoodApp.Domain.Entities
{
    public class ComboProduct : Entity<Guid>
    {
        public ComboProduct()
        {

        }
        public ComboProduct(Guid comboId, Guid productId) : base(Guid.NewGuid())
        {
            this.ComboId = comboId;
            this.ProductId = productId;
        }
        public Guid ComboId { get; set; }
        public Guid ProductId { get; set; }
    }
}
