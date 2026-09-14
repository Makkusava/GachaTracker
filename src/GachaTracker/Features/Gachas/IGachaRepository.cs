using GachaTracker.Domain.Gachas;

namespace GachaTracker.Features.Gachas;

public interface IGachaRepository
{
    Task<Gacha?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<Gacha?> GetBySlugAsync(string slug, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Gacha>> GetAllAsync(CancellationToken cancellationToken = default);

    void Add(Gacha gacha);
}
