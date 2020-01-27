using FoodApp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace FoodApp.Application.Common.ViewModels
{
    public class ProductDto
    {
        public ProductDto()
        {

        }
        public ProductDto(Product product, StoreProduct storeProduct)
        {
            this.Id = product.Id;
            this.Name = product.Name;
            this.Description = product.Description;
            this.ImageUrl = product.ImageUrl;
            this.Tags = product.Tags;
            this.Price = storeProduct.Price;
            this.DiscountRate = storeProduct.DiscountRate;
            this.AvailableCustomizations = storeProduct.AvailableCustomizations;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<string> Tags { get; set; }
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
