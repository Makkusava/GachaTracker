using GachaTracker.Domain.Gachas;
using GachaTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GachaTracker.Features.Gachas;

public sealed class GachaRepository(AppDbContext dbContext) : IGachaRepository
{
    public Task<Gacha?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        dbContext.Gachas.FirstOrDefaultAsync(g => g.Id == id, cancellationToken);

    public Task<Gacha?> GetBySlugAsync(string slug, CancellationToken cancellationToken = default) =>
        dbContext.Gachas.FirstOrDefaultAsync(g => g.Slug == slug.ToLower(), cancellationToken);

    public async Task<IReadOnlyList<Gacha>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await dbContext.Gachas.AsNoTracking().ToListAsync(cancellationToken);

    public void Add(Gacha gacha) => dbContext.Gachas.Add(gacha);
}
