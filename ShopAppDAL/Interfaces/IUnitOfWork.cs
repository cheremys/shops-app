using System;
using ShopAppDAL.Entities;

namespace ShopAppDAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Shop> Shops { get; }

        IRepository<SalesConsultant> SalesConsultants { get; }

        void Save();
    }
}
