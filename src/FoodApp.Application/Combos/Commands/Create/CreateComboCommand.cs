using FoodApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;

namespace FoodApp.Application.Combos.Commands.Create
{
    public class CreateComboCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public Guid StoreId { get; set; }
        public ICollection<Guid> Products { get; set; }
        public string ActionBy { get; set; }
        public Combo GetCombo()
        {
            return new Combo(this.Name)
            {
                Description = this.Description,
                ImageUrl = this.ImageUrl,
                CreatedBy = this.ActionBy
            };
        }
    }
}
