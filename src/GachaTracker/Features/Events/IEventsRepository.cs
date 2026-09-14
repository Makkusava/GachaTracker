using GachaTracker.Domain.Events;

namespace GachaTracker.Features.Events;

public interface IEventsRepository
{
    Task<GachaEvent?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<GachaEvent>> GetByGachaAsync(
        Guid gachaId,
        DateTime? asOfUtc = null,
        CancellationToken cancellationToken = default);

    void Add(GachaEvent gachaEvent);

    void Remove(GachaEvent gachaEvent);
}
