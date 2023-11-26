using Microsoft.EntityFrameworkCore;
using TimeTracker.Domain;

namespace TimeTracker.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseMySQL("your-connection-string-here");
}
