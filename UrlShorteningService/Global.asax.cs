using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System.Web.Http;
using UrlShorteningService.Models;
using UrlShorteningService.Processors;

namespace UrlShorteningService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RegisterUnityContainer();
        }

        private void RegisterUnityContainer()
        {
            UnityServiceLocator locator = new UnityServiceLocator(ConfigureUnityContainer());
            ServiceLocator.SetLocatorProvider(() => locator);
        }

        private IUnityContainer ConfigureUnityContainer()
        {
            UnityContainer container = new UnityContainer();
            //container.RegisterType<IFoo, Foo>(new ContainerControlledLifetimeManager());
            container.RegisterType<IBase62Encoder, Base62Encoder>();
            container.RegisterType<IUrlMapRepository, UrlMapRepository>();
            container.RegisterType<IUrlProcessor, Base62UrlProcessor>();

            Application["UnityContainer"] = container;

            return container;
        }

    }
}
