using GachaTracker.Domain.Events;
using GachaTracker.Domain.Gachas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GachaTracker.Infrastructure.Persistence.Configurations;

public sealed class GachaEventConfiguration : IEntityTypeConfiguration<GachaEvent>
{
    public void Configure(EntityTypeBuilder<GachaEvent> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(e => e.Description).HasMaxLength(2000);

        builder.Property(e => e.Type)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(30);

        builder.Property(e => e.ImageUrl).HasMaxLength(500);
        builder.Property(e => e.SourceUrl).HasMaxLength(500);

        builder.HasIndex(e => new { e.GachaId, e.StartsAtUtc });

        builder.HasOne<Gacha>()
            .WithMany()
            .HasForeignKey(e => e.GachaId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
