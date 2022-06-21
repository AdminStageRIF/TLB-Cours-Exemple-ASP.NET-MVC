﻿using Exemple_03.Infrastructure;
using Exemple_03.Models;
using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Exemple_04
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
      // model binders
      ModelBinders.Binders.Add(typeof(SessionModel), new SessionModelBinder());
    }
    // Session
    protected void Session_Start()
    {
      SessionModel sessionModel=new SessionModel();
      sessionModel.Randomizer=new Random(DateTime.Now.Millisecond);
      Session["data"] = sessionModel;
    }
  }

}