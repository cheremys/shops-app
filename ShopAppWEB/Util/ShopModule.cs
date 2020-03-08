using Ninject.Modules;
using ShopAppBll.Interfaces;
using ShopAppBll.Services;

namespace ShopAppWEB.Util
{
    public class ShopModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IShopService>().To<ShopService>();
        }
    }
}