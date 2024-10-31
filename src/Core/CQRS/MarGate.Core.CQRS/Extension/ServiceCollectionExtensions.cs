using FluentValidation;
using MarGate.Core.CQRS.Behavior;
using MarGate.Core.CQRS.Command;
using MarGate.Core.CQRS.Processor;
using MarGate.Core.CQRS.Query;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MarGate.Core.CQRS.Extension
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCQRS(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<ICQRSProcessor, CQRSProcessor>();

            services.AddMediatR(x => x.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            services
                .Scan(x => x.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                .AddClasses(a => a.AssignableTo(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            services
                .Scan(x => x.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                .AddClasses(a => a.AssignableTo(typeof(ICommandHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestValidationPipelineBehavior<,>));

            return services;
        }
    }
}
