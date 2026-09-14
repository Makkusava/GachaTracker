using GachaTracker.Infrastructure.Persistence;

namespace GachaTracker.Features.Gachas;

public sealed class GachaCatalogUnitOfWork(AppDbContext dbContext, IGachaRepository gachas) : IGachaCatalogUnitOfWork
{
    public IGachaRepository Gachas { get; } = gachas;

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        dbContext.SaveChangesAsync(cancellationToken);
}
