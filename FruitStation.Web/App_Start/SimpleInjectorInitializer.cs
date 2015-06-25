[assembly: WebActivator.PostApplicationStartMethod(typeof(FruitStation.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace FruitStation.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;

    using SimpleInjector;
    using SimpleInjector.Extensions;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    using FruitStation.Domain.Repositories.Abstact;
    using FruitStation.Domain.Repositories.Concrete;
    
    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            // Did you know the container can diagnose your configuration? 
            // Go to: https://simpleinjector.org/diagnostics
            var container = new Container();
            
            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            
            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {

            container.Register<ISaleRepository, InMemorySaleRepository>();

            container.Register<IFruitRepository, InMemoryFruitRepository>();

        }
    }
}