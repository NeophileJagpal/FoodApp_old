using FoodApp.Domain.Entities;
using System.Collections.Generic;

namespace FoddApp.Infrastructure.Persistence
{
    public interface IDatabase
    {
        ICollection<Store> Stores { get; set; }
        ICollection<Product> Products { get; set; }
        ICollection<Combo> Combos { get; set; }
        ICollection<StoreProduct> StoreProducts { get; set; }
        ICollection<StoreCombo> StoreCombos { get; set; }
        ICollection<ComboProduct> ComboProducts { get; set; }
    }
    public class Database : IDatabase
    {
        public Database()
        {
            this.Stores = new HashSet<Store>();
            this.Products = new HashSet<Product>();
            this.StoreProducts = new HashSet<StoreProduct>();
            this.Combos = new HashSet<Combo>();
        }
        public ICollection<Store> Stores { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Combo> Combos { get; set; }
        public ICollection<StoreProduct> StoreProducts { get; set; }
        public ICollection<StoreCombo> StoreCombos { get; set; }
        public ICollection<ComboProduct> ComboProducts { get; set; }
    }
}
