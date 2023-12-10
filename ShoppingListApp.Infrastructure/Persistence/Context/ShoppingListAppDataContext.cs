using Microsoft.EntityFrameworkCore;
using ShoppingListApp.Domain.Entities;
using System.Reflection.Metadata;

namespace ShoppingListApp.Infrastructure.Persistence.Context;
public class ShoppingListAppDataContext : DbContext
{
    public ShoppingListAppDataContext(DbContextOptions<ShoppingListAppDataContext> options) : base(options)
    {
    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<ShoppingList> ShoppingLists { get; set; }
    public DbSet<ShoppingItem> ShoppingItems { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Account>()
            .HasIndex(p => p.UserName)
            .IsUnique();
    }
}
