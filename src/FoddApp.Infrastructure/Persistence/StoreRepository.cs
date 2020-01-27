using FoodApp.Application.Interfaces;
using FoodApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FoddApp.Infrastructure.Persistence
{
    public class StoreRepository : IRepository<Store, Guid>
    {
        public StoreRepository(IDatabase database)
        {
            this.Database = database;
        }
        private IDatabase Database { get; }
        public async Task AddAsync(Store store)
        {
            await Task.Factory.StartNew(() => this.Database.Stores.Add(store));
        }

        public async Task<IEnumerable<Store>> FindAsync(Expression<Func<Store, bool>> predicate)
        {
            return await Task.Factory.StartNew(() =>
            {
                return this.Database.Stores.Where(predicate.Compile());
            });
        }

        public async Task<IEnumerable<Store>> GetAllAsync()
        {
            return await Task.Factory.StartNew(() =>
            {
                return this.Database.Stores;
            });
        }
    }
}
