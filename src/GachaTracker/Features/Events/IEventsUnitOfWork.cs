namespace GachaTracker.Features.Events;

public interface IEventsUnitOfWork
{
    IEventsRepository Events { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
