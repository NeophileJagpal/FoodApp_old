using FoodApp.Application.Interfaces;
using FoodApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FoddApp.Infrastructure.Persistence
{
    public class ComboRepository : IRepository<Combo, Guid>
    {
        public ComboRepository(IDatabase database)
        {
            this.Database = database;
        }
        private IDatabase Database { get; }
        public async Task AddAsync(Combo combo)
        {
            await Task.Factory.StartNew(() => this.Database.Combos.Add(combo));
        }

        public async Task<IEnumerable<Combo>> FindAsync(Expression<Func<Combo, bool>> predicate)
        {
            return await Task.Factory.StartNew(() =>
            {
                return this.Database.Combos.Where(predicate.Compile());
            });
        }

        public async Task<IEnumerable<Combo>> GetAllAsync()
        {
            return await Task.Factory.StartNew(() =>
            {
                return this.Database.Combos;
            });
        }
    }
}
