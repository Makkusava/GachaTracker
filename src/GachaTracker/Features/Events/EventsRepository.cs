using GachaTracker.Domain.Events;
using GachaTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GachaTracker.Features.Events;

public sealed class EventsRepository(AppDbContext dbContext) : IEventsRepository
{
    public Task<GachaEvent?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        dbContext.GachaEvents.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

    public async Task<IReadOnlyList<GachaEvent>> GetByGachaAsync(
        Guid gachaId,
        DateTime? asOfUtc = null,
        CancellationToken cancellationToken = default)
    {
        var query = dbContext.GachaEvents.AsNoTracking().Where(e => e.GachaId == gachaId);

        if (asOfUtc is { } cutoff)
        {
            query = query.Where(e => e.StartsAtUtc <= cutoff && e.EndsAtUtc >= cutoff);
        }

        return await query.OrderBy(e => e.StartsAtUtc).ToListAsync(cancellationToken);
    }

    public void Add(GachaEvent gachaEvent) => dbContext.GachaEvents.Add(gachaEvent);

    public void Remove(GachaEvent gachaEvent) => dbContext.GachaEvents.Remove(gachaEvent);
}
