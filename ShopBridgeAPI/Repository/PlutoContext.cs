using Microsoft.EntityFrameworkCore;
using ShopBridgeAPI.Models;

namespace Repository
{
    public class PlutoContext:DbContext
    {
       
        public PlutoContext(DbContextOptions options):base(options)
        {
            
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Item>().ToTable("Item");
        //}
        public DbSet<Item> Items { get; set; }
    }
}
