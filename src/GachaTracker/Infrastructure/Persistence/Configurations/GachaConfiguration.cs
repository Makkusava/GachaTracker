using GachaTracker.Domain.Gachas;
using GachaTracker.Infrastructure.Persistence.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GachaTracker.Infrastructure.Persistence.Configurations;

public sealed class GachaConfiguration : IEntityTypeConfiguration<Gacha>
{
    public void Configure(EntityTypeBuilder<Gacha> builder)
    {
        builder.HasKey(g => g.Id);

        builder.Property(g => g.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(g => g.Slug)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasIndex(g => g.Slug).IsUnique();

        builder.Property(g => g.IconUrl).HasMaxLength(500);

        builder.HasData(GachaSeedData.All);
    }
}
