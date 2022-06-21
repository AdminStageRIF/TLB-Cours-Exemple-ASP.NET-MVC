using Exemple_02.Infrastructure;
using Exemple_02.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Exemple_02
{
  // Remarque : pour obtenir des instructions sur l'activation du mode classique IIS6 ou IIS7, 
  // visitez http://go.microsoft.com/?LinkId=9394801

  public class MvcApplication : System.Web.HttpApplication
  {
    protected void Application_Start()
    {
      AreaRegistration.RegisterAllAreas();

      WebApiConfig.Register(GlobalConfiguration.Configuration);
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);
      // intialisation application - cas 1
      Application["infoAppli1"] = ConfigurationManager.AppSettings["infoAppli1"];
      // intialisation application - cas 2
      ApplicationModel data=new ApplicationModel();
      data.InfoAppli1=ConfigurationManager.AppSettings["infoAppli1"];
      Application["data"] = data;
      // model binders
      ModelBinders.Binders.Add(typeof(ApplicationModel), new ApplicationModelBinder());
      ModelBinders.Binders.Add(typeof(SessionModel), new SessionModelBinder());
    }

    protected void Session_Start()
    {
      // initialisation compteur - cas 1
      Session["compteur"] = 0;
      // initialisation compteur - cas 2
      Session["data"] = new SessionModel();
    }
  }
}