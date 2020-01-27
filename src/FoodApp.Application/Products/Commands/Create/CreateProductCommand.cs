using FoodApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;

namespace FoodApp.Application.Products.Commands.Create
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public Guid StoreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double DiscountRate { get; set; }
        public ICollection<Customization> AvailableCustomizations { get; set; }
        public string ImageUrl { get; set; }
        public string Tags { get; set; }
        public string ActionBy { get; set; }

        public Product GetProduct()
        {
            return new Product(this.Name)
            {
                Description = this.Description,
                ImageUrl = this.ImageUrl,
                Tags = this.Tags.Split(','),
                CreatedBy = this.ActionBy
            };
        }
    }
}
