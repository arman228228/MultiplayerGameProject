using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
    
    public DbSet<Account> Accounts { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(m =>
        {
            m.HasKey(p => p.Id);
            m.Property(p => p.Name).IsRequired().HasMaxLength(32);
            m.HasIndex(p => p.Name).IsUnique();
            m.HasIndex(p => p.Mail).IsUnique();
        });
    }
}