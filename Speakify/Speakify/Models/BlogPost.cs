namespace Speakify.Models;

public class BlogPost
{
    public Ulid Id { get; init; } = new Ulid();
    public required string Title { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime? PublishedAtUtc { get; set; }
    public bool IsPublished { get; set; } = false;
}
