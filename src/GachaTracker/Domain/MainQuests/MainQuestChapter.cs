using GachaTracker.Domain.Common;

namespace GachaTracker.Domain.MainQuests;

public sealed class MainQuestChapter : AuditableEntity
{
    public Guid GachaId { get; private set; }

    public string Title { get; private set; } = string.Empty;

    public string? Description { get; private set; }

    public int Order { get; private set; }

    public DateTime? ReleasedAtUtc { get; private set; }

    private MainQuestChapter()
    {
    }

    public MainQuestChapter(
        Guid id,
        Guid gachaId,
        string title,
        int order,
        string? description = null,
        DateTime? releasedAtUtc = null)
        : base(id)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Chapter title is required.", nameof(title));
        }

        if (order < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(order), "Chapter order cannot be negative.");
        }

        GachaId = gachaId;
        Title = title;
        Order = order;
        Description = description;
        ReleasedAtUtc = releasedAtUtc;
    }

    public void UpdateDetails(string title, string? description, int order)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Chapter title is required.", nameof(title));
        }

        if (order < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(order), "Chapter order cannot be negative.");
        }

        Title = title;
        Description = description;
        Order = order;
        Touch();
    }

    public void MarkReleased(DateTime releasedAtUtc)
    {
        ReleasedAtUtc = releasedAtUtc;
        Touch();
    }
}
