using GachaTracker.Domain.MainQuests;

namespace GachaTracker.Features.MainQuests;

public interface IMainQuestsRepository
{
    Task<MainQuestChapter?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<MainQuestChapter>> GetByGachaAsync(Guid gachaId, CancellationToken cancellationToken = default);

    void Add(MainQuestChapter chapter);

    void Remove(MainQuestChapter chapter);
}
