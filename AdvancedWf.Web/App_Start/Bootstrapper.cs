using AdvancedWf.Data.Infrastructure;
using AdvancedWf.Data.Repositories;
using AdvancedWf.Mapping;
using AdvancedWf.Service;
using Autofac;
using Autofac.Integration.Mvc;
 
using System.Linq;
using System.Reflection;
 
using System.Web.Mvc;

namespace AdvancedWf.Web.App_Start
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
            //Configure AutoMapper
            AutoMapperConfiguration.Configure();
        }

        /// <summary>
        ///   here  as  you  know  in any  concepts  Bootsrapper  that  you  make  the   startup  or   initiate the  project   and  here  we  will  use  autofac .
        ///   I will  Explain it  later
        /// </summary>
        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();
            
           
            // Repositories
            builder.RegisterAssemblyTypes(typeof(GadgetRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();


            // Services
            builder.RegisterAssemblyTypes(typeof(GadgetService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}