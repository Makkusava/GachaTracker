using GachaTracker.Domain.Common;

namespace GachaTracker.Domain.Events;

public sealed class GachaEvent : AuditableEntity
{
    public Guid GachaId { get; private set; }

    public string Title { get; private set; } = string.Empty;

    public string? Description { get; private set; }

    public EventType Type { get; private set; }

    public DateTime StartsAtUtc { get; private set; }

    public DateTime EndsAtUtc { get; private set; }

    public string? ImageUrl { get; private set; }

    public string? SourceUrl { get; private set; }

    public bool IsActive(DateTime nowUtc) => nowUtc >= StartsAtUtc && nowUtc <= EndsAtUtc;

    private GachaEvent()
    {
    }

    public GachaEvent(
        Guid id,
        Guid gachaId,
        string title,
        EventType type,
        DateTime startsAtUtc,
        DateTime endsAtUtc,
        string? description = null,
        string? imageUrl = null,
        string? sourceUrl = null)
        : base(id)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Event title is required.", nameof(title));
        }

        if (endsAtUtc < startsAtUtc)
        {
            throw new ArgumentException("Event end date cannot be before its start date.", nameof(endsAtUtc));
        }

        GachaId = gachaId;
        Title = title;
        Type = type;
        StartsAtUtc = startsAtUtc;
        EndsAtUtc = endsAtUtc;
        Description = description;
        ImageUrl = imageUrl;
        SourceUrl = sourceUrl;
    }

    public void Reschedule(DateTime startsAtUtc, DateTime endsAtUtc)
    {
        if (endsAtUtc < startsAtUtc)
        {
            throw new ArgumentException("Event end date cannot be before its start date.", nameof(endsAtUtc));
        }

        StartsAtUtc = startsAtUtc;
        EndsAtUtc = endsAtUtc;
        Touch();
    }

    public void UpdateDetails(string title, string? description, string? imageUrl, string? sourceUrl)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Event title is required.", nameof(title));
        }

        Title = title;
        Description = description;
        ImageUrl = imageUrl;
        SourceUrl = sourceUrl;
        Touch();
    }
}
