namespace Speakify.API.Data;

public class DataContext(DbContextOptions<DbContext> options) : DbContext(options)
{
    public DbSet<TimeEntry> TimeEntries { get; set; }
}
