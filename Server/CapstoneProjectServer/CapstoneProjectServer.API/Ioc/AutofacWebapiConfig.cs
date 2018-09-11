using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using CapstoneProjectServer.BusinessLogic.Services;
using CapstoneProjectServer.DataAccess.EF;
using CapstoneProjectServer.DataAccess.EF.Infrastructure;
using CapstoneProjectServer.DataAccess.EF.Repositories;
using System;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace CapstoneProjectServer.API.Ioc
{
    public class AutofacWebapiConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }


        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }


        private static IContainer RegisterServices(ContainerBuilder builder)
        {

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            //builder.RegisterType<DatabaseConnectionSettings>().As<IDatabaseConnectionSettings>();
            builder.RegisterType<RepositoryHelper>().As<IRepositoryHelper>();

            builder.RegisterType<DbContextTransactionProxy>().As<IDbContextTransactionProxy>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<CasptoneProjectContext>().AsSelf().InstancePerRequest();

            // Repositories
            builder.RegisterAssemblyTypes(typeof(ContactRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            // Services
            builder.RegisterAssemblyTypes(typeof(ContactService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();


            Container = builder.Build();

            return Container;

        }
    }

}