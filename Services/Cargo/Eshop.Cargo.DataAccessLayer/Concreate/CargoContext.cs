using EShop.Cargo.EntityLayer.Concreate;
using Microsoft.EntityFrameworkCore;

namespace EShop.Cargo.DtoLayer.Concreate
{
    public class CargoContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1441;Initial Catalog=MultiShopCargoDB;User=sa;Password=Ercan7154230");
        }
        public DbSet<CargoCompany> CargoCompanies { get; set; }
        public DbSet<CargoDetail> CargoDetails { get; set; }
        public DbSet<CargoCustomer> CargoCustomers { get; set; }
        public DbSet<CargoOperation> CargoOperations { get; set; }
    }
}
