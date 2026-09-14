using GachaTracker.Infrastructure.Persistence;

namespace GachaTracker.Features.MainQuests;

public sealed class MainQuestsUnitOfWork(AppDbContext dbContext, IMainQuestsRepository mainQuests) : IMainQuestsUnitOfWork
{
    public IMainQuestsRepository MainQuests { get; } = mainQuests;

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        dbContext.SaveChangesAsync(cancellationToken);
}
