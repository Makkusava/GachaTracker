using GachaTracker.Domain.Gachas;
using GachaTracker.Domain.MainQuests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GachaTracker.Infrastructure.Persistence.Configurations;

public sealed class MainQuestChapterConfiguration : IEntityTypeConfiguration<MainQuestChapter>
{
    public void Configure(EntityTypeBuilder<MainQuestChapter> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(c => c.Description).HasMaxLength(2000);

        builder.HasIndex(c => new { c.GachaId, c.Order });

        builder.HasOne<Gacha>()
            .WithMany()
            .HasForeignKey(c => c.GachaId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
