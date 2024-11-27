using ElevenIsland.Core;
using Microsoft.EntityFrameworkCore;

namespace ElevenIsland.Admin.Data;

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
        optionsBuilder.UseNpgsql("host=localhost;port=5432;Username=postgres;Password=post;Database=db1");
        // optionsBuilder.UseSqlite("Data Source=ElevenIsland.db");
    }
}