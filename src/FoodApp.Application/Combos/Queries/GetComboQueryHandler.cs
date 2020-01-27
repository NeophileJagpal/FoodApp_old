using FoodApp.Application.Common.ViewModels;
using FoodApp.Application.Interfaces;
using FoodApp.Application.Products.Queries;
using FoodApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FoodApp.Application.Combos.Queries
{
    public class GetComboQueryHandler : IRequestHandler<GetComboQuery, IEnumerable<ComboDto>>
    {
        public GetComboQueryHandler(IRepository<Combo, Guid> comboRepository,
            IRepository<StoreCombo, Guid> storeComboRepository,
            IRepository<ComboProduct, Guid> comboProductRepository,
            IMediator mediator)
        {
            this.ComboRepository = comboRepository;
            this.StoreComboRepository = storeComboRepository;
            this.ComboProductRepository = comboProductRepository;
            this.Mediator = mediator;
        }
        private IRepository<Combo, Guid> ComboRepository { get; }
        private IRepository<StoreCombo, Guid> StoreComboRepository { get; }
        private IRepository<ComboProduct, Guid> ComboProductRepository { get; }
        private IMediator Mediator { get; }
        public async Task<IEnumerable<ComboDto>> Handle(GetComboQuery request, CancellationToken cancellationToken)
        {
            ICollection<ComboDto> result = new HashSet<ComboDto>();
            if (request.StoreId == Guid.Empty)
                throw new ArgumentNullException(nameof(request.StoreId));


            var storeCombos = await this.StoreComboRepository.FindAsync(sp => sp.StoreId.Equals(request.StoreId));
            var storeProducts = await Mediator.Send(new GetProductQuery() { StoreId = request.StoreId });
            foreach (var combo in storeCombos)
            {
                var combos = await this.ComboRepository.FindAsync(c => c.Id.Equals(combo.Id));
                var comboProducts = await this.ComboProductRepository.FindAsync(cp => cp.ComboId.Equals(combo.ComboId));
                var cmb = new ComboDto(combos.FirstOrDefault());
                cmb.Price = combo.ComboPrice;
                var finalCmPrd = storeProducts.Where(i => comboProducts.Any(j => j.ProductId.Equals(i.Id)));
                foreach (var prd in finalCmPrd)
                {
                    cmb.Products.Add(prd);
                }
                result.Add(cmb);
            }
            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                result = result.Where(c => c.Name.Equals(request.Name)).ToList();
            }
            return result;
        }
    }
}
