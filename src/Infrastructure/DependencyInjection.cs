﻿using Hangfire;
using Hangfire.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace PropertyCore.Infrastructure
{
    /// <summary>
    /// Implements dependency injection for the Infrastructure project.
    /// </summary>
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {
            // Add Hangfire services.
            services.AddHangfire(config => config
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(configuration.GetConnectionString("HangfireConnection"), new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    DisableGlobalLocks = true
                }));
            var emailSettings = new EmailSettings
            {
                EmailId = configuration["EmailSettings:EmailId"],
                Host = configuration["EmailSettings:Host"],
                Name = configuration["EmailSettings:Name"],
                Port = Convert.ToInt32(configuration["EmailSettings:Port"]),
                UseSSL = Convert.ToBoolean(configuration["EmailSettings:UseSSL"])
            };
            services.AddSingleton(emailSettings);
            // Add the processing server as IHostedService
            services.AddHangfireServer();
            return services;
        }
    }
}