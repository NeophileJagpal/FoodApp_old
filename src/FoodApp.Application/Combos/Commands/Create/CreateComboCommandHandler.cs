using FoodApp.Application.Interfaces;
using FoodApp.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FoodApp.Application.Combos.Commands.Create
{
    public class CreateComboCommandHandler : IRequestHandler<CreateComboCommand, Guid>
    {
        public CreateComboCommandHandler(IRepository<Combo, Guid> comboRepository,
            IRepository<ComboProduct, Guid> comboProductRepository,
            IRepository<StoreCombo, Guid> storeComboRepository)
        {
            this.ComboRepository = comboRepository;
            this.ComboProductRepository = comboProductRepository;
            this.StoreComboRepository = storeComboRepository;
        }
        private IRepository<StoreCombo, Guid> StoreComboRepository { get; }
        private IRepository<ComboProduct, Guid> ComboProductRepository { get; }
        private IRepository<Combo, Guid> ComboRepository { get; }
        public async Task<Guid> Handle(CreateComboCommand request, CancellationToken cancellationToken)
        {
            var combo = request.GetCombo();
            await this.ComboRepository.AddAsync(combo);
            await this.StoreComboRepository.AddAsync(new StoreCombo(request.StoreId, combo.Id)
            {
                ComboPrice = request.Price,
                CreatedBy = request.ActionBy
            });
            foreach (var product in request.Products)
            {
                await this.ComboProductRepository.AddAsync(new ComboProduct(combo.Id, combo.Id)
                {
                    CreatedBy = request.ActionBy
                });
            }
            return combo.Id;
        }
    }
}
