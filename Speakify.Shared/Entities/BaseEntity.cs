namespace Speakify.Shared.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; init; } = new Ulid().ToGuid();
    public DateTime CreatedAtOtc { get; init; } = DateTime.UtcNow;
    public DateTime? UpdatedUtc { get; set; }
}
