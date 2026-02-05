using EShop.Comment.Entities;
using Microsoft.EntityFrameworkCore;

namespace EShop.Comment.Context
{
    public class CommentContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1442;Initial Catalog=MultiShopCommentDB;User=sa;Password=Ercan1993");
        }
        public DbSet<UserComment> UserComments { get; set; }
    }
}
