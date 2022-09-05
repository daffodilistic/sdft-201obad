using Microsoft.EntityFrameworkCore;
using PhishyBank.Models;

namespace PhishyBank.Data;
public class BankContext : DbContext
{
    public DbSet<User> Users { get; init; } = null!;
    public DbSet<AccountTransaction> AccountTransactions { get; init; } = null!;
    public DbSet<Account> Accounts { get; init; } = null!;

    public BankContext(DbContextOptions<BankContext> options)
        : base(options)
    {
        // DO NOT DELETE THIS BLANK CONSTRUCTOR, OR ELSE .NET WILL COMPLAIN
    }
}