using Exemple_03.Models;
using Exemples.Controllers;
using System;
using System.Web.Mvc;

namespace Exemple_03.Controllers
{
    public class SecondController : I18NController
    {
      // Action14-GET
      [HttpGet]
      public ViewResult Action14Get()
      {
        return View("Action14Get", new ViewModel14());
      }

      // Action14-POST
      [HttpPost]
      public ViewResult Action14Post(ViewModel14 modèle)
      {
        return View("Action14Get", modèle);
      }

      // Action15
      public ViewResult Action15(FormCollection formData)
      {
        // méthode HTTP
        string method = Request.HttpMethod.ToLower();
        // modèle
        ViewModel15 modèle = new ViewModel15();
        if (method == "get")
        {
          modèle.StrDate1 = "";
        }
        else
        {
          TryUpdateModel(modèle, formData);
          modèle.StrDate1 = modèle.Date1.ToString(modèle.FormatDate);
        }
        // affichage vue
        return View("Action15", modèle);
      }

      // Action16-GET
      [HttpGet]
      public ViewResult Action16Get()
      {
        ViewBag.info = string.Format("Contrôleur={0}, Action={1}", RouteData.Values["controller"], RouteData.Values["action"]);
        return View("Action16Get");
      }

      // Action16-POST
      [HttpPost]
      public ViewResult Action16Post(string data)
      {
        ViewBag.info = string.Format("Contrôleur={0}, Action={1}, Data={2}", RouteData.Values["controller"], RouteData.Values["action"], data);
        return View("Action16Get");
      }

      // Action17-GET
      [HttpGet]
      public ViewResult Action17Get()
      {
        ViewBag.info = string.Format("Contrôleur={0}, Action={1}", RouteData.Values["controller"], RouteData.Values["action"]);
        return View();
      }

      // langue
      [HttpPost]
      public RedirectResult Lang(string url)
      {
        // on redirige le client vers url
        return new RedirectResult(url);
      }

    }
}
