using Application.Data;
using Domain.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Data;

public class AppDbContext : DbContext, IUnitOfWork
{
    private readonly IPublisher _publisher;
    public AppDbContext(DbContextOptions<AppDbContext> options, IPublisher publisher) : base(options)
    {
        _publisher = publisher;
    }
    public DbSet<Domain.Game.Game> Games { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        //Ovo se radi zbog domaineventa
        var domainEvents = ChangeTracker.Entries<Entity>()
            .Select(e => e.Entity)
            .Where(e => e.DomainEvents.Any())
            .SelectMany(e => e.DomainEvents).ToList();

        //Moze da se publishuje pre
        var result = await base.SaveChangesAsync(cancellationToken);
        //Ili posle Save changes(malo je bolje after)

        foreach (var domainEvent in domainEvents)
        {
            System.Console.WriteLine("OVO JE GRESKA" + domainEvent);
            await _publisher.Publish(domainEvent);
        }

        return result;
    }
}