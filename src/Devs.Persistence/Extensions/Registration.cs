using Devs.Application.Interfaces.Repositories;
using Devs.Persistence.Contexts;
using Devs.Persistence.Interceptors;
using Devs.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Devs.Persistence.Extensions;

public static class Registration
{
    public static IServiceCollection AddPersistenceRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<DbCommandInterceptor, QueryCommandInterceptor>();

        services.AddDbContext<DevsContext>(conf =>
        {
            var connStr = configuration["DevsDbConnectionString"].ToString();

            conf.UseSqlServer(connStr, opt =>
            {
                opt.EnableRetryOnFailure();

            }).AddInterceptors(new QueryCommandInterceptor());

        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();



        return services;
    }
}