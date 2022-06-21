using System.Text;
using System.Web.Mvc;

namespace Exemple_01.Controllers
{
  public class SecondController : Controller
  {
    // /Second/Action01
    public ContentResult Action01()
    {
      return Content("Contrôleur=Second, Action=Action01", "text/plain", Encoding.UTF8);
    }
    // /Second/Action02
    [HttpPost]
    public ContentResult Action02()
    {
      return Content("Contrôleur=Second, Action=Action02", "text/plain", Encoding.UTF8);
    }
    // /Second/Action03
    public ContentResult Action03()
    {
      string texte = string.Format("Contrôleur={0}, Action={1}", RouteData.Values["controller"], RouteData.Values["action"]);
      return Content(texte, "text/plain", Encoding.UTF8);
    }

  }
}
