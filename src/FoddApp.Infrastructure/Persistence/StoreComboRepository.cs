using FoodApp.Application.Interfaces;
using FoodApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FoddApp.Infrastructure.Persistence
{
    public class StoreComboRepository : IRepository<StoreCombo, Guid>
    {
        public StoreComboRepository(IDatabase database)
        {
            this.Database = database;
        }
        private IDatabase Database { get; }
        public async Task AddAsync(StoreCombo storeCombo)
        {
            await Task.Factory.StartNew(() => this.Database.StoreCombos.Add(storeCombo));
        }

        public async Task<IEnumerable<StoreCombo>> FindAsync(Expression<Func<StoreCombo, bool>> predicate)
        {
            return await Task.Factory.StartNew(() =>
            {
                return this.Database.StoreCombos.Where(predicate.Compile());
            });
        }

        public async Task<IEnumerable<StoreCombo>> GetAllAsync()
        {
            return await Task.Factory.StartNew(() =>
            {
                return this.Database.StoreCombos;
            });
        }
    }
}
