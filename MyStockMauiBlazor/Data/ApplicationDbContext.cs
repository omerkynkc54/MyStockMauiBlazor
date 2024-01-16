using Microsoft.EntityFrameworkCore;
using MyStockMauiBlazor.Models;


namespace MyStockMauiBlazor.Data;

internal class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }
    public DbSet<LoginLog> Categories { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
}
