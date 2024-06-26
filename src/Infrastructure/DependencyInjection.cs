using Application.Abstractions.Caching;
using Application.Data;
using Domain.Game;
using Domain.Shared;
using Infrastructure.Caching;
using Infrastructure.EmailService;
using Infrastructure.Persistance.Data;
using Infrastructure.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMemoryCache();
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("DefaulDbConnection")));

        services.AddScoped<IUnitOfWork>(sp =>
            sp.GetRequiredService<AppDbContext>());

        // services.AddScoped<IGameRepository, GameRepository>();
        //Decorator Pattern
        services.AddKeyedScoped<IGameRepository, GameRepository>("og");
        services.AddScoped<IGameRepository, CachedMemberRepository>();

        services.AddScoped<IEmailService, EmailServicee>();

        //Zato sto je kes samo jedna instanca je potrebna
        services.AddSingleton<ICacheService, CachingService>();

        return services;
    }

}
