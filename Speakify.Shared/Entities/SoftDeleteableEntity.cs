namespace Speakify.Shared.Entities;

public class SoftDeleteableEntity : BaseEntity
{
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAtUtc { get; set; }
}
