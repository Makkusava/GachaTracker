using GachaTracker.Domain.Common;

namespace GachaTracker.Domain.Gachas;

public sealed class Gacha : Entity
{
    public string Name { get; private set; } = string.Empty;

    public string Slug { get; private set; } = string.Empty;

    public string? IconUrl { get; private set; }

    private Gacha()
    {
    }

    public Gacha(Guid id, string name, string slug, string? iconUrl = null)
        : base(id)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Gacha name is required.", nameof(name));
        }

        if (string.IsNullOrWhiteSpace(slug))
        {
            throw new ArgumentException("Gacha slug is required.", nameof(slug));
        }

        Name = name;
        Slug = slug.ToLowerInvariant();
        IconUrl = iconUrl;
    }

    public void Rename(string name, string slug)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Gacha name is required.", nameof(name));
        }

        if (string.IsNullOrWhiteSpace(slug))
        {
            throw new ArgumentException("Gacha slug is required.", nameof(slug));
        }

        Name = name;
        Slug = slug.ToLowerInvariant();
    }

    public void SetIcon(string? iconUrl) => IconUrl = iconUrl;
}
