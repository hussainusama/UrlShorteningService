using System.Web.Http;
using Unity;
using UrlShorteningService.Service.Encoders;
using UrlShorteningService.Service.Repositories;
using UrlShorteningService.Service.UrlProcessors;
using UrlShorteningService.Service.DependencyResolvers;

namespace UrlShorteningService.Service
{
    public static class DependencyInjectionConfig
    {
        public static void Register(HttpConfiguration config)
        {
            UnityContainer container = new UnityContainer();
            container.RegisterType<IBase62Encoder, Base62Encoder>();
            container.RegisterType<IUrlMapRepository, UrlMapRepository>();
            container.RegisterType<IUrlProcessor, Base62UrlProcessor>();

            config.DependencyResolver = new UnityResolver(container);
        }
    }
}