using MarGate.Core.Persistence.Context;
using MarGate.Core.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MarGate.Core.Persistence.Extension;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistence<TWriteContext>(this IServiceCollection services, IConfiguration configuration) where TWriteContext : WriteDbContext
    {
        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        //services.AddDbContext<TWriteContext>();
        //services.AddScoped<WriteDbContext, TWriteContext>();
        services.AddScoped((_) =>
        {
            var a = new DbContextOptionsBuilder<WriteDbContext>();
            a.UseSqlServer(configuration.GetConnectionString("WriteDb"));
            return new WriteDbContext(a.Options);

        });

        return services;
    }

    public static IServiceCollection AddPersistence<TWriteContext, TReadContext>(this IServiceCollection services, IConfiguration configuration) where TWriteContext : WriteDbContext where TReadContext : ReadDbContext
    {
        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        //services.AddDbContext<TWriteContext>(x =>
        //{
        //    x.UseSqlServer(configuration.GetConnectionString("WriteDb"));
        //});

        //services.AddDbContext<TReadContext>(x =>
        //{
        //    x.UseSqlServer(configuration.GetConnectionString("WriteDb"));
        //});

        services.AddScoped((_) =>
        {
            var a = new DbContextOptionsBuilder<WriteDbContext>();
            a.UseSqlServer(configuration.GetConnectionString("WriteDb"));
            return new WriteDbContext(a.Options);

        });

        services.AddScoped((_) =>
        {
            var optionsBuilder = new DbContextOptionsBuilder<ReadDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("WriteDb"));
            return new ReadDbContext(optionsBuilder.Options);

        });

        //services.AddScoped<ReadDbContext, TReadContext>();

        return services;
    }
}
