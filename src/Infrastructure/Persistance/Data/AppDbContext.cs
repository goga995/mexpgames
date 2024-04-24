using Application.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Data;

public class AppDbContext : DbContext, IUnitOfWork
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    public DbSet<Domain.Game.Game> Games { get; set; }
}