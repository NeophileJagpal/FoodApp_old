namespace FoodApp.Domain.Entities
{
    public class Customization
    {
        public Customization(string name, double cost)
        {
            this.Name = name;
            this.Cost = cost;
        }
        public string Name { get; set; }
        public double Cost { get; set; }
    }
}
