using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Reflection;

using Ninject.Web.Mvc;
using Ninject;

using MyCMS.Domain.Ninject;
using MyCMS.Infrastructure.Ninject;

namespace MyCMS.Web
{
    // PRUEBA DE VIDA


    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : NinjectHttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected override IKernel CreateKernel()
        {
            IKernel kernel = new StandardKernel(new DomainLayerDependencyModule(), new InfrastructureLayerDependencyModule());
            kernel.Load(Assembly.LoadFrom(@"C:\Users\DIEGO\YAM-CMS\MyCMS.Data\bin\Debug\MyCMS.Data.dll"));

            if (!kernel.HasModule("MyCMS.Data.Ninject.DataLayerDependencyModule"))
                throw new Exception("El módulo de dependencias 'PersistenceLayerDependencyModule' no está presente");

            if (!kernel.HasModule("MyCMS.Domain.Ninject.DomainLayerDependencyModule"))
                throw new Exception("El módulo de dependencias 'BusinessLayerDependencyModule' no está presente");

            return kernel;
        }

        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            //log4net.Config.XmlConfigurator.Configure();

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            RegisterModelBinders();
        }

        private void RegisterModelBinders()
        {
            //Todavía ninguno
        }
    }
}