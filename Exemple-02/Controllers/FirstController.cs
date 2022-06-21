using Exemple_02.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Exemple_02.Controllers
{
  public class FirstController : Controller
  {
    // Action01
    public ContentResult Action01(string nom)
    {
      return Content(string.Format("Contrôleur=First, Action=Action01, nom={0}", nom), "text/plain", Encoding.UTF8);
    }
    // Action02
    public ContentResult Action02(int age)
    {
      string texte = string.Format("Contrôleur={0}, Action={1}, âge={2}", RouteData.Values["controller"], RouteData.Values["action"], age);
      return Content(texte, "text/plain", Encoding.UTF8);
    }
    // Action03
    public ContentResult Action03(int? age)
    {
      string texte = string.Format("Contrôleur={0}, Action={1}, âge={2}", RouteData.Values["controller"], RouteData.Values["action"], age);
      return Content(texte, "text/plain", Encoding.UTF8);
    }
    // Action04
    public ContentResult Action04(int? age)
    {
      bool valide = ModelState.IsValid;
      string texte = string.Format("Contrôleur={0}, Action={1}, âge={2}, valide={3}", RouteData.Values["controller"], RouteData.Values["action"], age, valide);
      return Content(texte, "text/plain", Encoding.UTF8);
    }
    // Action05
    public ContentResult Action05(int? age)
    {
      string erreurs = getErrorMessagesFor(ModelState);
      string texte = string.Format("Contrôleur={0}, Action={1}, âge={2}, valide={3}, erreurs={4}", RouteData.Values["controller"], RouteData.Values["action"], age, ModelState.IsValid, erreurs);
      return Content(texte, "text/plain", Encoding.UTF8);
    }
    // Action06
    public ContentResult Action06(double? poids, int? age)
    {
      string erreurs = getErrorMessagesFor(ModelState);
      string texte = string.Format("Contrôleur={0}, Action={1}, poids={2}, âge={3}, valide={4}, erreurs={5}", RouteData.Values["controller"], RouteData.Values["action"], poids, age, ModelState.IsValid, erreurs);
      return Content(texte, "text/plain", Encoding.UTF8);
    }
    // Action07
    public ContentResult Action07(ActionModel01 modèle)
    {
      string erreurs = getErrorMessagesFor(ModelState);
      string texte = string.Format("Contrôleur={0}, Action={1}, poids={2}, âge={3}, valide={4}, erreurs={5}", RouteData.Values["controller"], RouteData.Values["action"], modèle.Poids, modèle.Age, ModelState.IsValid, erreurs);
      return Content(texte, "text/plain", Encoding.UTF8);
    }
    // Action08
    public ContentResult Action08(ActionModel02 modèle)
    {
      string erreurs = getErrorMessagesFor(ModelState);
      string texte = string.Format("Contrôleur={0}, Action={1}, poids={2}, âge={3}, valide={4}, erreurs={5}", RouteData.Values["controller"], RouteData.Values["action"], modèle.Poids, modèle.Age, ModelState.IsValid, erreurs);
      return Content(texte, "text/plain", Encoding.UTF8);
    }

    // Action09
    public ContentResult Action09(ActionModel02 modèle, DateTime? date)
    {
      string erreurs = getErrorMessagesFor(ModelState);
      string texte = string.Format("Contrôleur={0}, Action={1}, poids={2}, âge={3}, date={4}, valide={5}, erreurs={6}", RouteData.Values["controller"], RouteData.Values["action"], modèle.Poids, modèle.Age, date, ModelState.IsValid, erreurs);
      return Content(texte, "text/plain", Encoding.UTF8);
    }

    // Action10
    public ContentResult Action10(ActionModel03 modèle)
    {
      string erreurs = getErrorMessagesFor(ModelState);
      string texte = string.Format("email={0}, jour={1}, info1={2}, info2={3}, info3={4}, erreurs={5}",
        modèle.Email, modèle.Jour, modèle.Info1, modèle.Info2, modèle.Info3, erreurs);
      return Content(texte, "text/plain", Encoding.UTF8);
    }

    // Action11
    public ContentResult Action11(ActionModel04 modèle)
    {
      string erreurs = getErrorMessagesFor(ModelState);
      string texte = string.Format("URL={0}, Info1={1}, Info2={2}, CC={3},erreurs={4}",
        modèle.Url, modèle.Info1, modèle.Info2, modèle.Cc, erreurs);
      return Content(texte, "text/plain", Encoding.UTF8);
    }

    // Action12
    public ContentResult Action12(ActionModel05 modèle)
    {
      string erreurs = getErrorMessagesFor(ModelState);
      string texte = string.Format("taux={0}, erreurs={1}", modèle.Taux, erreurs);
      return Content(texte, "text/plain", Encoding.UTF8);
    }

    // Action13
    public ContentResult Action13(string[] data)
    {
      string strData = "";
      if (data != null && data.Length != 0)
      {
        strData = string.Join(",", data);
      }
      string texte = string.Format("data=[{0}]", strData);
      return Content(texte, "text/plain", Encoding.UTF8);
    }

    // Action14
    public ContentResult Action14(List<int> data)
    {
      string erreurs = getErrorMessagesFor(ModelState);
      string strData = "";
      if (data != null && data.Count != 0)
      {
        strData = string.Join(",", data);
      }
      string texte = string.Format("data=[{0}], erreurs=[{1}]", strData, erreurs);
      return Content(texte, "text/plain", Encoding.UTF8);
    }

    // Action15
    public ContentResult Action15(ActionModel06 modèle)
    {
      string erreurs = getErrorMessagesFor(ModelState);
      string texte = string.Format("valide={0}, info1={1}, info2={2}, erreurs={3}", ModelState.IsValid, modèle.Info1, modèle.Info2, erreurs);
      return Content(texte, "text/plain", Encoding.UTF8);
    }

    // Action16
    public ContentResult Action16()
    {
      // on récupère le contexte de la requête HTTP
      HttpContextBase contexte = ControllerContext.HttpContext;
      // on récupère les infos de portée Application
      string infoAppli1 = contexte.Application["infoAppli1"] as string;
      // et celles de portée Session
      int? compteur = contexte.Session["compteur"] as int?;
      compteur++;
      contexte.Session["compteur"] = compteur;
      // la réponse au client
      string texte = string.Format("infoAppli1={0}, compteur={1}", infoAppli1, compteur);
      return Content(texte, "text/plain", Encoding.UTF8);
    }

    // Action17
    public ContentResult Action17(ApplicationModel applicationData, SessionModel sessionData)
    {
      // on récupère les infos de portée Application
      string infoAppli1 = applicationData.InfoAppli1;
      // et celles de portée Session
      sessionData.Compteur++;
      int compteur = sessionData.Compteur;
      // la réponse au client
      string texte = string.Format("infoAppli1={0}, compteur={1}", infoAppli1, compteur);
      return Content(texte, "text/plain", Encoding.UTF8);
    }

    // Action18
    public ContentResult Action18()
    {
      ActionModel05 modèle = new ActionModel05();
      TryUpdateModel(modèle);
      string erreurs = getErrorMessagesFor(ModelState);
      string texte = string.Format("taux={0}, erreurs={1}", modèle.Taux, erreurs);
      return Content(texte, "text/plain", Encoding.UTF8);
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
