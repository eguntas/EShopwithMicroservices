using Eshop.Discount.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Eshop.Discount.Context
{
    public class DapperContext:DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ASUS\\SQLEXPRESS01;initial catalog=EShopDiscountDB;integrated Security=true");
        }
        public DbSet<Coupon> Coupons { get; set; }

        public IDbConnection CreatedConnection() => new SqlConnection(_connectionString);
    }
}
