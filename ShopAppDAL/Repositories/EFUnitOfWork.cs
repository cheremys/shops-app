using System;
using ShopAppDAL.EF;
using ShopAppDAL.Entities;
using ShopAppDAL.Interfaces;

namespace ShopAppDAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ShopContext dataBase;
        private ShopRepository shopRepository;
        private SalesConsultantRepository salesConsultantRepository;

        public EFUnitOfWork()
        {
            dataBase = new ShopContext();
        }

        public IRepository<Shop> Shops
        {
            get
            {
                return shopRepository != null ? shopRepository
                    : shopRepository = new ShopRepository(dataBase);
            }
        }

        public IRepository<SalesConsultant> SalesConsultants
        {
            get
            {
                return salesConsultantRepository != null ? salesConsultantRepository
                    : salesConsultantRepository = new SalesConsultantRepository(dataBase);
            }
        }

        public void Save()
        {
            dataBase.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dataBase.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
