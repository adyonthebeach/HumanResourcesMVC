using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace HumanResources.SimpleWebApplication
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<IDatabaseConnections, DatabaseConnections>();
            container.RegisterType<IHumanResourcesRepository, HumanResourcesRepository>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}