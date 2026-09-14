using GachaTracker.Domain.Events;
using GachaTracker.Domain.Gachas;
using GachaTracker.Domain.MainQuests;
using Microsoft.EntityFrameworkCore;

namespace GachaTracker.Infrastructure.Persistence;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Gacha> Gachas => Set<Gacha>();

    public DbSet<GachaEvent> GachaEvents => Set<GachaEvent>();

    public DbSet<MainQuestChapter> MainQuestChapters => Set<MainQuestChapter>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
