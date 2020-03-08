using Ninject.Modules;
using ShopAppBll.Interfaces;
using ShopAppBll.Services;

namespace ShopAppWEB.Util
{
    public class SalesConsultantModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISalesConsultantService>().To<SalesConsultantService>();
        }
    }
}