namespace GachaTracker.Features.Gachas;

public interface IGachaCatalogUnitOfWork
{
    IGachaRepository Gachas { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
