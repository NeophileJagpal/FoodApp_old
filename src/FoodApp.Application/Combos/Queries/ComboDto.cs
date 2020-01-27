using FoodApp.Application.Common.ViewModels;
using FoodApp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace FoodApp.Application.Combos.Queries
{
    public class ComboDto
    {
        public ComboDto(Combo combo)
        {
            this.Id = combo.Id;
            this.Name = combo.Name;
            this.Description = combo.Description;
            this.ImageUrl = combo.ImageUrl;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public ICollection<ProductDto> Products { get; set; }
    }
}
