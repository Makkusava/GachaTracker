namespace GachaTracker.Domain.Common;

public abstract class AuditableEntity : Entity
{
    public DateTime CreatedAtUtc { get; protected set; }

    public DateTime? UpdatedAtUtc { get; protected set; }

    protected AuditableEntity(Guid id)
        : base(id)
    {
        CreatedAtUtc = DateTime.UtcNow;
    }

    protected AuditableEntity()
    {
    }

    public void Touch() => UpdatedAtUtc = DateTime.UtcNow;
}
