using MarGate.Core.UnitOfWork.Context;
using MarGate.Core.UnitOfWork.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MarGate.Core.UnitOfWork.Extension;
public static class ServiceCollectionExtensions
{
    public class UnitOfWorkOptions
    {
        public string WriteConnectionString { get; set; }
        public string ReadConnectionString { get; set; }
    }
    public static IServiceCollection AddUnitOfWork<TWriteContext>(this IServiceCollection services, Action<UnitOfWorkOptions> setupAction) where TWriteContext : WriteDbContext
    {
        var option = new UnitOfWorkOptions();
        setupAction.Invoke(option);

        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        services.AddDbContext<TWriteContext>(x =>
        {
            x.UseSqlServer(option.WriteConnectionString);
        });

        services.AddScoped<WriteDbContext, TWriteContext>();

        return services;
    }

    public static IServiceCollection AddUnitOfWork<TWriteContext, TReadContext>(this IServiceCollection services, Action<UnitOfWorkOptions> setupAction) where TWriteContext : WriteDbContext where TReadContext : ReadDbContext
    {
        var option = new UnitOfWorkOptions();
        setupAction.Invoke(option);

        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        services.AddDbContext<TWriteContext>(x =>
        {
            x.UseSqlServer(option.WriteConnectionString);
        });

        services.AddScoped<WriteDbContext, TWriteContext>();

        services.AddDbContext<TReadContext>(x =>
        {
            x.UseSqlServer(option.ReadConnectionString);
        });

        services.AddScoped<ReadDbContext, TReadContext>();

        return services;
    }
}
