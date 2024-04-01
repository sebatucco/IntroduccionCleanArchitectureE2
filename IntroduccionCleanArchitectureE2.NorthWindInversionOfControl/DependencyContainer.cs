using FluentValidation;
using IntroduccionCleanArchitectureE2.NorthWindEntities.Interfaces;
using IntroduccionCleanArchitectureE2.NorthWindRepositoriesEFCore.DataContext;
using IntroduccionCleanArchitectureE2.NorthWindRepositoriesEFCore.Repositories;
using IntroduccionCleanArchitectureE2.NorthWindUseCases.Common.Behaviors;
using IntroduccionCleanArchitectureE2.NorthWindUseCases.CreateOrder;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace IntroduccionCleanArchitectureE2.NorthWindInversionOfControl
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<Context>(options => options.UseSqlServer(configuration.GetConnectionString("NorthWindDb")));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //services.AddMediatR(cfg => 
            //{
            //    cfg.RegisterServicesFromAssembly(typeof(CreateOrderInteractor).Assembly);
            //});  // cojeda

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(CreateOrderInteractor)));
            services.AddValidatorsFromAssembly(typeof(CreateOrderValidator).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
