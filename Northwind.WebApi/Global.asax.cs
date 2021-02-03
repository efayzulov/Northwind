using Ninject;
using Ninject.Web.WebApi;
using Ninject.Web.WebApi.Filter;
using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Validation;
using System.Web.Routing;

namespace Northwind.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            // Diğer kodlar...
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(CreateKernel());

            log4net.Config.XmlConfigurator.Configure();
        }

        private IKernel CreateKernel()
        {
            IKernel kernel = new StandardKernel();

            kernel.Bind<DefaultModelValidatorProviders>().ToConstant(new DefaultModelValidatorProviders(GlobalConfiguration.Configuration.Services.GetModelValidatorProviders()));


            kernel.Bind<DefaultFilterProviders>().ToConstant(new DefaultFilterProviders(GlobalConfiguration.Configuration.Services.GetFilterProviders()));
        
            //Oracle Örnek
            //kernel.Bind<ICategoryRepository>().To<OracleCategoryRepository>();

            kernel.Bind<ICategoryRepository>().To<AdoCategoryRepository>();
            kernel.Bind<ICategoryService>().To<CategoryManager>();

            kernel.Bind<IProductRepository>().To<AdoProductRepository>();
            kernel.Bind<IProductService>().To<ProductManager>();

            kernel.Bind<ICustomerRepository>().To<AdoCustomerRepository>();
            kernel.Bind<ICustomerService>().To<CustomerManager>();

            kernel.Bind<IEmployeRepository>().To<AdoEmployeRepository>();
            kernel.Bind<IEmployeService>().To<EmployeManager>();

            kernel.Bind<IShipperRepository>().To<AdoShipperRepository>();
            kernel.Bind<IShipperService>().To<ShipperManager>();

            kernel.Bind<ISupplierRepository>().To<AdoSupplierRepository>();
            kernel.Bind<ISupplierService>().To<SupplierManager>();

            kernel.Bind<IOrderRepository>().To<AdoOrderRepository>();
            kernel.Bind<IOrderServicecs>().To<OrderManager>();

            return kernel;
        }
    }
}
