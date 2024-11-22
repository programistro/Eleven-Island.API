using System.Data.Common;
using ElevenIsland.Core;
using Microsoft.EntityFrameworkCore;

namespace ElevenIsland.API.Data;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();
    
    public DbSet<Customer> Customers => Set<Customer>();
    
    public AppDbContext() { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //Host=79.174.88.137;Port=15394;Database=users;Username=user1;Password=@Roma2021090
        // optionsBuilder.UseNpgsql("host=62.113.118.151;port=5432;Username=admin;Password=Abc#1234;Database=postgres");
        optionsBuilder.UseSqlite("Data Source=ElevenIsland.db");
    }
}