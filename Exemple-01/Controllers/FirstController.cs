using System;
using System.Dynamic;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace Exemple_01.Controllers
{
  public class FirstController : Controller
  {
    // Index
    public ViewResult Index()
    {
      return View();
    }
    // Action01
    public ContentResult Action01()
    {
      return Content("<h1>Action [Action01]</h1>", "text/plain", Encoding.UTF8);
    }
    // Action02
    public ContentResult Action02()
    {
      string data = "<action><name>Action02</name><description>renvoie un texte XML</description></action>";
      return Content(data, "text/xml", Encoding.UTF8);
    }
    // Action03
    public JsonResult Action03()
    {
      dynamic personne = new ExpandoObject();
      personne.nom = "someone";
      personne.age = 20;
      return Json(personne, JsonRequestBehavior.AllowGet);
    }
    // Action04
    public string Action04()
    {
      return "<h3>Contrôleur=First, Action=Action04</h3>";
    }
    // Action05
    public EmptyResult Action05()
    {
      return new EmptyResult();
    }
    // Action06
    public RedirectResult Action06()
    {
      return new RedirectResult("/First/Action05");
    }
    // Action07
    public RedirectResult Action07()
    {
      return new RedirectResult("/First/Action05", true);
    }
    // Action08
    public RedirectToRouteResult Action08()
    {
      return new RedirectToRouteResult("Default", new RouteValueDictionary(new { controller = "First", action = "Action05" }));
    }
    // Action09
    [HttpGet]
    public void Action09()
    {
      string nom = Request.QueryString["nom"] ?? "inconnu";
      Response.AddHeader("Content-Type", "text/plain");
      Response.Write(string.Format("<h3>Action09</h3>nom={0}", nom));
    }

  }
}
