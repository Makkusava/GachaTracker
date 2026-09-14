namespace GachaTracker.Features.MainQuests;

public interface IMainQuestsUnitOfWork
{
    IMainQuestsRepository MainQuests { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
