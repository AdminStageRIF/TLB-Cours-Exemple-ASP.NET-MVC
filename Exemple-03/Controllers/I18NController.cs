using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Globalization;

namespace Exemples.Controllers
{
  public abstract class I18NController : Controller
  {
    public I18NController()
    {
      // on récupère le contexte de la requête courante
      HttpContext httpContext = System.Web.HttpContext.Current;
      // on examine la requête à la recherche du paramètre [lang]
      // on le cherche dans les paramètres de l'URL
      string langue = httpContext.Request.QueryString["lang"];
      if (langue == null)
      {
        // on le cherche dans les paramètres postés
        langue = httpContext.Request.Form["lang"];
      }
      if (langue == null)
      {
        // on le cherche dans la session de l'utilisateur
        langue = httpContext.Session["lang"] as string;
      }
      if (langue == null)
      {
        // 1er paramètre de l'entête HTTP AcceptLanguages
        langue = httpContext.Request.UserLanguages[0];
      }
      if (langue == null)
      {
        // culture fr-FR
        langue = "fr-FR";
      }
      // on met la langue en session
      httpContext.Session["lang"] = langue;
      // on modifie les cultures du thread            
      Thread.CurrentThread.CurrentCulture = new CultureInfo(langue);
      Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
    }
  }
}