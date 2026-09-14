using GachaTracker.Infrastructure.Persistence;

namespace GachaTracker.Features.Events;

public sealed class EventsUnitOfWork(AppDbContext dbContext, IEventsRepository events) : IEventsUnitOfWork
{
    public IEventsRepository Events { get; } = events;

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        dbContext.SaveChangesAsync(cancellationToken);
}
