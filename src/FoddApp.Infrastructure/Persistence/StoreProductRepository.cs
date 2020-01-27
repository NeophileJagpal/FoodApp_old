using FoodApp.Application.Interfaces;
using FoodApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FoddApp.Infrastructure.Persistence
{
    public class StoreProductRepository : IRepository<StoreProduct, Guid>
    {
        public StoreProductRepository(IDatabase database)
        {
            this.Database = database;
        }
        private IDatabase Database { get; }
        public async Task AddAsync(StoreProduct productConfiguration)
        {
            await Task.Factory.StartNew(() => this.Database.StoreProducts.Add(productConfiguration));
        }

        public async Task<IEnumerable<StoreProduct>> FindAsync(Expression<Func<StoreProduct, bool>> predicate)
        {
            return await Task.Factory.StartNew(() =>
            {
                return this.Database.StoreProducts.Where(predicate.Compile());
            });
        }

        public async Task<IEnumerable<StoreProduct>> GetAllAsync()
        {
            return await Task.Factory.StartNew(() =>
            {
                return this.Database.StoreProducts;
            });
        }
    }
}
