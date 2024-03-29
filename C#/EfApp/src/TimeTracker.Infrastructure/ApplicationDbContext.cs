﻿using Microsoft.EntityFrameworkCore;
using TimeTracker.Domain;

namespace TimeTracker.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseMySql("server=192.168.1.9;port=3306;database=timeTrackerDb;user=root;password=my-secret-pw", new MariaDbServerVersion("11.2.2"));
}
