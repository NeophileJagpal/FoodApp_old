using FoodApp.Application.Interfaces;
using FoodApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FoddApp.Infrastructure.Persistence
{
    public class ComboProductRepository : IRepository<ComboProduct, Guid>
    {
        public ComboProductRepository(IDatabase database)
        {
            this.Database = database;
        }
        private IDatabase Database { get; }
        public async Task AddAsync(ComboProduct comboProduct)
        {
            await Task.Factory.StartNew(() => this.Database.ComboProducts.Add(comboProduct));
        }

        public async Task<IEnumerable<ComboProduct>> FindAsync(Expression<Func<ComboProduct, bool>> predicate)
        {
            return await Task.Factory.StartNew(() =>
            {
                return this.Database.ComboProducts.Where(predicate.Compile());
            });
        }

        public async Task<IEnumerable<ComboProduct>> GetAllAsync()
        {
            return await Task.Factory.StartNew(() =>
            {
                return this.Database.ComboProducts;
            });
        }
    }
}
