using System;

namespace FoodApp.Domain.Entities
{
    public class StoreCombo : Entity<Guid>
    {
        public StoreCombo()
        {

        }
        public StoreCombo(Guid storeId, Guid productId) : base(Guid.NewGuid())
        {
            this.StoreId = storeId;
            this.ComboId = productId;
        }
        public Guid StoreId { get; set; }
        public Guid ComboId { get; set; }
        public double ComboPrice { get; set; }
    }
}
