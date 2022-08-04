using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using PhishyBank.Models;

namespace PhishyBank.Data;
public class BankContext : DbContext
{
    public DbSet<User> Students { get; init; } = null!;

    public BankContext(DbContextOptions<BankContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("User");
    }

}