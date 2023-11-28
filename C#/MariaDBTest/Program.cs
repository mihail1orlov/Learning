// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

using (ApplicationContext db = new ApplicationContext())
{
    var user1 = new User { Id = Guid.NewGuid(), Name = "Tom" };
    var user2 = new User { Id = Guid.NewGuid(), Name = "Alice" };

    db.Users.AddRange(user1, user2);
    db.SaveChanges();
}

using (ApplicationContext db = new ApplicationContext())
{
    var users = db.Users.ToList();
    Console.WriteLine("Objects list:");
    foreach (User u in users)
    {
        Console.WriteLine($"Name: {u.Name}; Id: {u.Id}");
    }
}

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public ApplicationContext()
    {
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(
            "Server=192.168.1.9;Port=3306;User ID=root;Database=myTestDb;password=my-secret-pw",
            new MySqlServerVersion(new Version(11, 2, 2))
        );
    }
}

public class User
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}