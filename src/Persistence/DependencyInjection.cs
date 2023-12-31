﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PropertyCore.Application.Common.Interfaces;

namespace PropertyCore.Persistence
{
    /// <summary>
    /// Configures the service dependencies used in the Persistence layer
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Configures the service collection
        /// </summary>
        /// <param name="services">An implementation of <see cref="IServiceCollection"></see></param>
        /// <param name="configuration">An implementation of <see cref="IConfiguration"></see></param>
        /// <returns></returns>
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DHStoreContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DHStoreDatabase")).EnableSensitiveDataLogging());

            services.AddScoped<IDHStoreContext>(provider => provider.GetService<DHStoreContext>());
            

            return services;
        }
    }
}
