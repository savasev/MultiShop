using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Persistence.Context;

public class OrderContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1440;Initial Catalog=MultiShopOrderDb;User=sa;Password=*Q1w2e3r4t5*");
    }

    public DbSet<Address> Addresses { get; set; }

    public DbSet<OrderDetail> OrderDetails { get; set; }

    public DbSet<Ordering> Orderings { get; set; }
}
