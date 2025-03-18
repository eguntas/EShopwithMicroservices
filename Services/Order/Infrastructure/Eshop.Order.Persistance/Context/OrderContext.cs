using Eshop.Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eshop.Order.Persistance.Context
{
    public class OrderContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1440;Initial Catalog=MultiShopOrderDB;User=sa;Password=Ercan7154230.");
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Ordering> Orderings { get; set; }


    }
}
