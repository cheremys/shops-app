using Ninject.Modules;
using ShopAppDAL.Interfaces;
using ShopAppDAL.Repositories;

namespace ShopAppBll.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>();
        }
    }
}
