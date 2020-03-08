using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ShopAppDAL.EF;
using ShopAppDAL.Entities;
using ShopAppDAL.Interfaces;

namespace ShopAppDAL.Repositories
{
    class SalesConsultantRepository : IRepository<SalesConsultant>
    {
        private ShopContext dataBase;

        public SalesConsultantRepository(ShopContext context)
        {
            this.dataBase = context;
        }

        public IEnumerable<SalesConsultant> GetAll()
        {
            return dataBase.SalesConsultants;
        }

        public SalesConsultant Get(int id)
        {
            return dataBase.SalesConsultants.Find(id);
        }

        public void Create(SalesConsultant item)
        {
            dataBase.SalesConsultants.Add(item);
        }

        public void Update(SalesConsultant item)
        {
            dataBase.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<SalesConsultant> Find(Func<SalesConsultant, bool> predicate)
        {
            return dataBase.SalesConsultants.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            SalesConsultant SalesConsultant = dataBase.SalesConsultants.Find(id);
            if (SalesConsultant != null)
                dataBase.SalesConsultants.Remove(SalesConsultant);
        }
    }
}
