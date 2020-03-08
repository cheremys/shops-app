using System.Collections.Generic;
using System.Data.Entity;
using ShopAppDAL.EF;
using ShopAppDAL.Entities;

namespace ShopAppDAL.Migrations
{
    internal sealed class ContextInitializer : DropCreateDatabaseIfModelChanges<ShopContext>
    {
        protected override void Seed(ShopContext dataBase)
        {
            var beatrix = new SalesConsultant { Name = "Beatrix", LastName = "Kiddo" };
            var lincoln = new SalesConsultant { Name = "Lincoln", LastName = "Hawk" };
            var cataleya = new SalesConsultant { Name = "Cataleya", LastName = "Restrepo" };
            var stacker = new SalesConsultant { Name = "Stacker", LastName = "Pentecost" };
            var james = new SalesConsultant { Name = "James", LastName = "Bond" };

            dataBase.SalesConsultants.AddRange(new List<SalesConsultant> { beatrix, lincoln, cataleya, stacker, james });
            dataBase.SaveChanges();

            var bergdorfGoodman = new Shop
            {
                Name = "Bergdorf Goodman",
                Address = "754 5th Ave, New York, NY 10019, USA",
                SalesConsultants = new List<SalesConsultant> { beatrix, lincoln }
            };

            var bloomingdales = new Shop
            {
                Name = "Bloomingdale's",
                Address = "Bloomingdale's, New York, NY 10022, USA",
                SalesConsultants = new List<SalesConsultant> { cataleya, stacker }
            };

            var macys = new Shop
            {
                Name = "Macy's",
                Address = "151 W 34th St, New York, NY 10001, USA",
                SalesConsultants = new List<SalesConsultant> { james }
            };

            dataBase.Shops.AddRange(new List<Shop> { bergdorfGoodman, bloomingdales, macys });
            dataBase.SaveChanges();
        }
    }
}
