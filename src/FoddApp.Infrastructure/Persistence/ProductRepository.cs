using FoodApp.Application.Interfaces;
using FoodApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FoddApp.Infrastructure.Persistence
{
    public class ProductRepository : IRepository<Product, Guid>
    {
        public ProductRepository(IDatabase database)
        {
            this.Database = database;
        }
        private IDatabase Database { get; }
        public async Task AddAsync(Product product)
        {
            await Task.Factory.StartNew(() => this.Database.Products.Add(product));
        }

        public async Task<IEnumerable<Product>> FindAsync(Expression<Func<Product, bool>> predicate)
        {
            return await Task.Factory.StartNew(() =>
            {
                return this.Database.Products.Where(predicate.Compile());
            });
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await Task.Factory.StartNew(() =>
            {
                return this.Database.Products;
            });
        }
    }
}
