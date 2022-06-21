using Exemple_03.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using System.Linq;

namespace Exemple_03.Controllers
{
  public class FirstController : Controller
  {
    // Index
    public ActionResult Index()
    {
      return View();
    }

    // Action01
    public ViewResult Action01()
    {
      ViewBag.info = string.Format("Contrôleur={0}, Action={1}", RouteData.Values["controller"], RouteData.Values["action"]);
      return View();
    }
    // Action02
    public ViewResult Action02(ActionModel03 modèle)
    {
      string erreurs = getErrorMessagesFor(ModelState);
      return View(new ViewModel01() { Email = modèle.Email, Jour = modèle.Jour, Info1 = modèle.Info1, Info2 = modèle.Info2, Info3 = modèle.Info3, Erreurs = erreurs });
    }

    // Action03
    public ViewResult Action03(ActionModel04 modèle)
    {
      modèle.Erreurs = getErrorMessagesFor(ModelState);
      return View(modèle);
    }

    // Action04
    public ViewResult Action04()
    {
      return View(new ViewModel02());
    }

    // Action05
    [HttpGet]
    public ViewResult Action05()
    {
      return View(new ViewModel05());
    }

    // Action06-GET
    [HttpGet]
    public ViewResult Action06()
    {
      return View("Action06Get", new ViewModel05());
    }

    // Action06-POST
    [HttpPost]
    public ViewResult Action06(ActionModel06 modèle)
    {
      return View("Action06Post", modèle);
    }

    // Action07-GET
    [HttpGet]
    public ViewResult Action07(SessionModel session)
    {
      ViewModel05 modèleVue = new ViewModel05();
      session.Personnes = modèleVue.Personnes;
      return View("Action07Get", modèleVue);
    }

    // Action07-POST
    [HttpPost]
    public ViewResult Action07(SessionModel session, ActionModel06 modèle)
    {
      Personne2 personne = session.Personnes.Where(p => p.Id == modèle.PersonneId).First<Personne2>();
      string strPersonne = string.Format("{0} {1}", personne.Prénom, personne.Nom);
      return View("Action07Post", (object)strPersonne);
    }

    // Action08-GET
    [HttpGet]
    public ViewResult Action08Get(ApplicationModel application)
    {
      ViewBag.info = string.Format("Contrôleur={0}, Action={1}", RouteData.Values["controller"], RouteData.Values["action"]);
      return View("Formulaire", new ViewModel08(application));
    }

    // Action08-POST
    [HttpPost]
    public ViewResult Action08Post(ApplicationModel application, FormCollection posted)
    {
      ViewBag.info = string.Format("Contrôleur={0}, Action={1}", RouteData.Values["controller"], RouteData.Values["action"]);
      ViewModel08 modèle = new ViewModel08(application);
      TryUpdateModel(modèle, posted);
      // traitement des valeurs non postées
      if (posted["CheckBoxesField"] == null)
      {
        modèle.CheckBoxesField = new string[] { };
      }
      if (posted["SimpleChoiceListField"] == null)
      {
        modèle.SimpleChoiceListField = "";
      }
      if (posted["MultipleChoiceListField"] == null)
      {
        modèle.MultipleChoiceListField = new string[] { };
      }
      // affichage formulaire
      return View("Formulaire", modèle);
    }

    // Action09-GET
    [HttpGet]
    public ViewResult Action09Get(ApplicationModel application)
    {
      ViewBag.info = string.Format("Contrôleur={0}, Action={1}", RouteData.Values["controller"], RouteData.Values["action"]);
      return View("Formulaire2", new ViewModel09(application));
    }

    // Action09-POST
    [HttpPost]
    public ViewResult Action09Post(ApplicationModel application, FormCollection posted)
    {
      ViewBag.info = string.Format("Contrôleur={0}, Action={1}", RouteData.Values["controller"], RouteData.Values["action"]);
      ViewModel09 modèle = new ViewModel09(application);
      TryUpdateModel(modèle, posted);
      // traitement des valeurs non postées
      if (posted["SimpleChoiceListField"] == null)
      {
        modèle.SimpleChoiceListField = "";
      }
      if (posted["MultipleChoiceListField"] == null)
      {
        modèle.MultipleChoiceListField = new string[] { };
      }
      // affichage formulaire
      return View("Formulaire2", modèle);
    }

    // Action10-GET
    [HttpGet]
    public ViewResult Action10Get()
    {
      return View(new ViewModel10());
    }
    // Action10-POST
    [HttpPost]
    public ContentResult Action10Post(ViewModel10 modèle)
    {
      string erreurs = getErrorMessagesFor(ModelState);
      string texte = string.Format("Contrôleur={0}, Action={1}, valide={2}, erreurs={3}", RouteData.Values["controller"], RouteData.Values["action"], ModelState.IsValid, erreurs);
      return Content(texte, "text/plain", Encoding.UTF8);
    }

    // Action11-GET
    [HttpGet]
    public ViewResult Action11Get()
    {
      return View("Action11Get", new ViewModel11());
    }
    // Action11-POST
    [HttpPost]
    public ViewResult Action11Post(ViewModel11 modèle)
    {
      return View("Action11Get", modèle);
    }

    // Action12-GET
    [HttpGet]
    public ViewResult Action12Get()
    {
      return View("Action12Get", new ViewModel11());
    }

    // Action12-POST
    [HttpPost]
    public ViewResult Action12Post(ViewModel11 modèle)
    {
      return View("Action12Get", modèle);
    }

    // Action13-GET
    [HttpGet]
    public ViewResult Action13Get()
    {
      return View("Action13Get", new ViewModel11());
    }

    // Action13-POST
    [HttpPost]
    public ViewResult Action13Post(ViewModel11 modèle)
    {
      return View("Action13Get", modèle);
    }

    // ---------------------------------- helpers
    // ensemble des messages d'erreur
    private string getErrorMessagesFor(ModelStateDictionary état)
    {
      List<String> erreurs = new List<String>();
      string messages = string.Empty;
      if (!état.IsValid)
      {
        foreach (ModelState modelState in état.Values)
        {
          foreach (ModelError error in modelState.Errors)
          {
            erreurs.Add(getErrorMessageFor(error));
          }
        }
        foreach (string message in erreurs)
        {
          messages += string.Format("[{0}]", message);
        }
      }
      return messages;
    }

    // le message d'erreur lié à un élément du modèle de l'action
    private string getErrorMessageFor(ModelError error)
    {
      if (error.ErrorMessage != null && error.ErrorMessage.Trim() != string.Empty)
      {
        return error.ErrorMessage;
      }
      if (error.Exception != null && error.Exception.InnerException == null && error.Exception.Message != string.Empty)
      {
        return error.Exception.Message;
      }
      if (error.Exception != null && error.Exception.InnerException != null && error.Exception.InnerException.Message != string.Empty)
      {
        return error.Exception.InnerException.Message;
      }
      return string.Empty;
    }
  }

}

