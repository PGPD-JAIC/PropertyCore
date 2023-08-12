using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PropertyCore.Application.Common.Behaviors;
using PropertyCore.Application.Common.Models;
using System.Net;
using System.Reflection;

namespace PropertyCore.Application
{
    /// <summary>
    /// Configures Dependency Injection for the Application 
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Configures services for the Application layer
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestAuthorizationBehavior<,>));
            services.AddAuthorizersFromAssembly(Assembly.GetAssembly(typeof(Authorization)));
            return services;
        }
    }
}
