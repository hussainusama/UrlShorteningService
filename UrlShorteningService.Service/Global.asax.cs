using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Unity;
using UrlShorteningService.Service.Encoders;
using UrlShorteningService.Service.Repositories;
using UrlShorteningService.Service.UrlProcessors;

namespace UrlShorteningService.Service
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configure(DependencyInjectionConfig.Register);
        }
    }
}
