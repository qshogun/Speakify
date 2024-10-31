namespace Speakify.Shared.Entities;

public abstract class SoftDeleteableEntity : BaseEntity
{
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAtUtc { get; set; }
}
