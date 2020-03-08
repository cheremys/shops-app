using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ShopAppDAL.EF;
using ShopAppDAL.Entities;
using ShopAppDAL.Interfaces;

namespace ShopAppDAL.Repositories
{
    public class ShopRepository : IRepository<Shop>
    {
        private ShopContext dataBase;

        public ShopRepository(ShopContext context)
        {
            this.dataBase = context;
        }

        public IEnumerable<Shop> GetAll()
        {
            return dataBase.Shops.Include(s => s.SalesConsultants);
        }

        public Shop Get(int id)
        {
            return dataBase.Shops.Find(id);
        }

        public void Create(Shop item)
        {
            dataBase.Shops.Add(item);
        }

        public void Update(Shop item)
        {
            dataBase.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<Shop> Find(Func<Shop, bool> predicate)
        {
            return dataBase.Shops.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Shop Shop = dataBase.Shops.Find(id);
            if (Shop != null)
                dataBase.Shops.Remove(Shop);
        }
    }
}
