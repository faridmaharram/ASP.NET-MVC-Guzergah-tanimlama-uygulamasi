using Autofac;
using Autofac.Integration.Mvc;
using BusWeb.Core.Infrastructure;
using BusWeb.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusWeb.UI.Class
{
    public class BootStrapper
    {

        public static void RunConfig()
        {
            BuildAutoFac();
        }

        private static void BuildAutoFac()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<CityRepository>().As<ICityRepository>();
            builder.RegisterType<RouteRepository>().As<IRouteRepository>();
            builder.RegisterType<RouteTypeRepository>().As<IRouteTypeRepository>();
            builder.RegisterType<StationRepository>().As<IStationRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

    }
}