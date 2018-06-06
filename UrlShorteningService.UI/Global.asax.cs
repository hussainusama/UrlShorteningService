using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Unity;
using Unity.ServiceLocation;
using UrlShorteningService.UI.UrlRedirectionServices;
using UrlShorteningService.UI.UrlRetreivers;

namespace UrlShorteningService.UI
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            UnityContainer container = new UnityContainer();
            container.RegisterType<IUrlRedirectionService, UrlRedirectionService>();
            container.RegisterType<IUrlRetriever, UrlRetriever>();

            UnityServiceLocator locator = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => locator);
        }
    }
}