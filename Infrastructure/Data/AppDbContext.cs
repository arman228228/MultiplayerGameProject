using Domain.Entities.AccountQuests;
using Domain.Entities.Accounts;
using Domain.Entities.Cars;
using Domain.Entities.Quests;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Quest> Quests { get; set; }
    public DbSet<AccountQuest> AccountQuests { get; set; }
    public DbSet<Car> Cars { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(m =>
        {
            m.HasKey(a => a.Id);
            m.Property(a => a.Nickname).IsRequired().HasMaxLength(32);
            m.HasIndex(a => a.Nickname).IsUnique();
            m.HasIndex(a => a.Mail).IsUnique();
            
            m.HasOne(a => a.Car)
                .WithOne(c => c.Account)
                .HasForeignKey<Car>(c => c.AccountId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Quest>(m =>
        {
            m.HasKey(q => q.Id);
            m.HasIndex(q => new {q.Name, q.AccountId}).IsUnique();
            
            m.HasOne(q => q.Account)
                .WithMany(a => a.Quests)
                .HasForeignKey(q => q.AccountId)
                .IsRequired();
        });

        modelBuilder.Entity<AccountQuest>(m =>
        {
            m.HasKey(aq => aq.Id);

            m.HasOne(aq => aq.Account)
                .WithMany(a => a.AccountQuests)
                .HasForeignKey(aq => aq.AccountId)
                .OnDelete(DeleteBehavior.Cascade);
            
            m.HasOne(aq => aq.Quest)
                .WithMany(q => q.AccountQuests)
                .HasForeignKey(aq => aq.QuestId)
                .OnDelete(DeleteBehavior.Cascade);
                
            m.HasIndex(aq => new { aq.AccountId, aq.QuestId }).IsUnique();
        });
        
        modelBuilder.Entity<Car>(m =>
        {
            m.HasKey(c => c.Id);
        });
    }
}