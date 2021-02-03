using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using Ninject.Web.WebApi;
using Ninject.Web.WebApi.Filter;
using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
using Northwind.Web.UI.ApiClients;
using Northwind.Web.UI.ApiClients.Abstract;

namespace Northwind.Web.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Diðer kodlar...
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(CreateKernel());
        }
        private IKernel CreateKernel()
        {
            IKernel kernel = new StandardKernel();

            kernel.Bind<DefaultModelValidatorProviders>().ToConstant(new DefaultModelValidatorProviders(GlobalConfiguration.Configuration.Services.GetModelValidatorProviders()));


            kernel.Bind<DefaultFilterProviders>().ToConstant(new DefaultFilterProviders(GlobalConfiguration.Configuration.Services.GetFilterProviders()));


            kernel.Bind<ICategoryApiClient>().To<CategoryApiClient>();
          

            return kernel;
        }
    }
}
