using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject.Modules;
using Ninject.Web.Mvc;
using ShopAppBll.Infrastructure;
using ShopAppWEB.Util;

namespace ShopAppWEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // dependency injection
            NinjectModule shopModule = new ShopModule();
            NinjectModule salesConsultantModule = new SalesConsultantModule();
            NinjectModule serviceModule = new ServiceModule();

            var kernel = new Ninject.StandardKernel(shopModule, salesConsultantModule, serviceModule);
            //you just unbind ninject validator and there should be no collision with default validator.
            kernel.Unbind<ModelValidatorProvider>();
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
