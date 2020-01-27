namespace FoodApp.Domain.Entities
{
    using System;

    public abstract class Entity<TKey>
    where TKey : IEquatable<TKey>
    {
        public Entity()
        {

        }
        public Entity(TKey id)
        {
            this.Id = id;
            this.CreatedOn = DateTime.UtcNow;
            this.UpdatedOn = DateTime.UtcNow;
        }
        public TKey Id { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}
