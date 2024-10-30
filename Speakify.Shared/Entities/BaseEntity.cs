namespace Speakify.Shared.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public DateTime CreatedAtOtc { get; init; } = DateTime.UtcNow;
    public DateTime? UpdatedUtc { get; set; }
}
