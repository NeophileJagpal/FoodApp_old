using System;
using System.Collections.Generic;

namespace FoodApp.Domain.Entities
{
    public class StoreProduct : Entity<Guid>
    {
        public StoreProduct()
        {
            this.AvailableCustomizations = new HashSet<Customization>();
        }
        public StoreProduct(Guid storeId, Guid productId) : base(Guid.NewGuid())
        {
            this.StoreId = storeId;
            this.ProductId = productId;
        }
        public Guid StoreId { get; set; }
        public Guid ProductId { get; set; }
        public double Price { get; set; }
        public double DiscountRate { get; set; }
        public double FinalPrice
        {
            get
            {
                return this.Price + (this.Price * this.DiscountRate) / 100;
            }
        }
        public ICollection<Customization> AvailableCustomizations { get; set; }

    }
}
