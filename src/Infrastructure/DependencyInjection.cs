using Application.Data;
using Domain.Game;
using Infrastructure.Persistance.Data;
using Infrastructure.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("DefaulDbConnection")));

        services.AddScoped<IUnitOfWork>(sp =>
            sp.GetRequiredService<AppDbContext>());

        services.AddScoped<IGameRepository, GameRepository>();

        return services;
    }

}
