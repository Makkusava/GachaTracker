using GachaTracker.Domain.MainQuests;
using GachaTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GachaTracker.Features.MainQuests;

public sealed class MainQuestsRepository(AppDbContext dbContext) : IMainQuestsRepository
{
    public Task<MainQuestChapter?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        dbContext.MainQuestChapters.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

    public async Task<IReadOnlyList<MainQuestChapter>> GetByGachaAsync(
        Guid gachaId,
        CancellationToken cancellationToken = default) =>
        await dbContext.MainQuestChapters
            .AsNoTracking()
            .Where(c => c.GachaId == gachaId)
            .OrderBy(c => c.Order)
            .ToListAsync(cancellationToken);

    public void Add(MainQuestChapter chapter) => dbContext.MainQuestChapters.Add(chapter);

    public void Remove(MainQuestChapter chapter) => dbContext.MainQuestChapters.Remove(chapter);
}
