using Autofac;
using Autofac.Integration.Mvc;
using Hangfire;
using Models;
using Services;
using System.Reflection;

namespace Mvc5.App_Start
{
    public class HangfireConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            // builder.Register...

            builder.RegisterType<EmployeesService>().As<IEmployeesService>().ExternallyOwned();

            // 註冊Controllers
            //builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();

            // 註冊DbContextFactory

            // 註冊 Repository UnitOfWork
            //builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));

            // 註冊Services        
            //var services = Assembly.Load("Services");
            //builder.RegisterAssemblyTypes(services).AsImplementedInterfaces().PropertiesAutowired();

            builder.RegisterFilterProvider();

            // 建立容器
            IContainer container = builder.Build();

            GlobalConfiguration.Configuration.UseAutofacActivator(container);
        }
    }
}