using Microsoft.EntityFrameworkCore;
using ShoppingListApp.Domain.Entities;

namespace ShoppingListApp.Infrastructure.Persistence.Context;
public class ShoppingListAppDataContext : DbContext
{
    public ShoppingListAppDataContext(DbContextOptions<ShoppingListAppDataContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<ShoppingList> ShoppingLists { get; set; }
    public DbSet<ShoppingItem> ShoppingItems { get; set; }
}
