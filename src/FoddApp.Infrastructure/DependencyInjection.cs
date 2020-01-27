using FoddApp.Infrastructure.Persistence;
using FoodApp.Application.Interfaces;
using FoodApp.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FoddApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IDatabase, Database>();
            services.AddTransient<IRepository<Store, Guid>, StoreRepository>();
            services.AddTransient<IRepository<Product, Guid>, ProductRepository>();
            services.AddTransient<IRepository<StoreProduct, Guid>, StoreProductRepository>();
            return services;
        }
    }
}
