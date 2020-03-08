using System.Data.Entity;
using ShopAppDAL.Entities;
using ShopAppDAL.Migrations;

namespace ShopAppDAL.EF
{
    public class ShopContext : DbContext
    {
        public ShopContext() : base("ShopContext")
        {
        }

        static ShopContext()
        {
            Database.SetInitializer<ShopContext>(new ContextInitializer());
        }

        public DbSet<Shop> Shops { get; set; }

        public DbSet<SalesConsultant> SalesConsultants { get; set; }
    }
}
