using Microsoft.EntityFrameworkCore;
using Speakify.Models;

namespace Speakify.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<BlogPost> BlogPosts { get; set; }
}
