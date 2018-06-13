using Autofac;
using Autofac.Integration.Mvc;
using Models;
using System.Reflection;
using System.Web.Mvc;

namespace Mvc5
{
    public class AutofacConfig
    {
        public static void Register()
        {
            // 容器建立者
            ContainerBuilder builder = new ContainerBuilder();

            // 註冊Controllers
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();

            // 註冊DbContextFactory

            // 註冊 Repository UnitOfWork
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));

            // 註冊Services        
            var services = Assembly.Load("Services");
            builder.RegisterAssemblyTypes(services).AsImplementedInterfaces().PropertiesAutowired();

            builder.RegisterFilterProvider();

            // 建立容器
            IContainer container = builder.Build();

            // 解析容器內的型別           
            AutofacDependencyResolver resolver = new AutofacDependencyResolver(container);

            // 建立相依解析器           
            DependencyResolver.SetResolver(resolver);
            
        }
    }
}