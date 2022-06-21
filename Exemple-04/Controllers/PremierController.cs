using Exemple_03.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Web.Mvc;

namespace Exemple_04.Models
{
  public class PremierController : Controller
  {

    [HttpGet]
    public ViewResult Action01Get()
    {
      ViewModel01 modèle = new ViewModel01();
      modèle.HeureChargement = DateTime.Now.ToString("hh:mm:ss");
      return View(modèle);
    }

    [HttpPost]
    public PartialViewResult Action01Post(FormCollection postedData, SessionModel session)
    {
      // simulation attente
      Thread.Sleep(2000);
      // validation modèle
      ViewModel01 modèle = new ViewModel01();
      // les heures de chargement et de calcul
      modèle.HeureChargement = DateTime.Now.ToString("hh:mm:ss");
      modèle.HeureCalcul = DateTime.Now.ToString("hh:mm:ss");
      // mise à jour du modèle
      TryUpdateModel(modèle, postedData);
      if (!ModelState.IsValid)
      {
        // on retourne une erreur
        modèle.Erreur = getErrorMessagesFor(ModelState);
        return PartialView("Action01Error", modèle);
      }
      // une fois sur deux, on simule une erreur
      int val = session.Randomizer.Next(2);
      if (val == 0)
      {
        modèle.Erreur = "[erreur aléatoire]";
        return PartialView("Action01Error", modèle);
      }
      // calculs
      modèle.AplusB = string.Format("{0}", modèle.A + modèle.B);
      modèle.AmoinsB = string.Format("{0}", modèle.A - modèle.B);
      modèle.AmultipliéparB = string.Format("{0}", modèle.A * modèle.B);
      modèle.AdiviséparB = string.Format("{0}", modèle.A / modèle.B);
      // vue
      return PartialView("Action01Success", modèle);
    }

    [HttpGet]
    public ViewResult Action02Get()
    {
      ViewModel02 modèle = new ViewModel02();
      modèle.HeureChargement = DateTime.Now.ToString("hh:mm:ss");
      return View(modèle);
    }

    [HttpPost]
    public JsonResult Action02Post(FormCollection postedData, SessionModel session)
    {
      // une exception artificielle pour tester la fonction d'erreur de l'appel Ajax
      //throw new Exception();
      // simulation attente
      Thread.Sleep(2000);
      // validation modèle
      ViewModel02 modèle = new ViewModel02();
      // les heures de chargement et de calcul
      string HeureChargement = DateTime.Now.ToString("hh:mm:ss");
      string HeureCalcul = DateTime.Now.ToString("hh:mm:ss");
      // mise à jour du modèle
      TryUpdateModel(modèle, postedData);
      if (!ModelState.IsValid)
      {
        // on retourne une erreur
        return Json(new { Erreur = getErrorMessagesFor(ModelState), HeureCalcul = HeureCalcul });
      }
      // une fois sur deux, on simule une erreur
      int val = session.Randomizer.Next(2);
      if (val == 0)
      {
        // on retourne une erreur
        return Json(new { Erreur = "[erreur aléatoire]", HeureCalcul = HeureCalcul });
      }
      // calculs
      string AplusB = string.Format("{0}", modèle.A + modèle.B);
      string AmoinsB = string.Format("{0}", modèle.A - modèle.B);
      string AmultipliéparB = string.Format("{0}", modèle.A * modèle.B);
      string AdiviséparB = string.Format("{0}", modèle.A / modèle.B);
      // on retourne les résultats
      return Json(new { Erreur = "", AplusB = AplusB, AmoinsB = AmoinsB, AmultipliéparB = AmultipliéparB, AdiviséparB = AdiviséparB, HeureCalcul = HeureCalcul });
    }

    [HttpGet]
    public ViewResult Action03Get()
    {
      return View();
    }

    [HttpGet]
    public PartialViewResult Action04(string page = "1")
    {
      string vue = "Page1";
      if (page == "2")
      {
        vue = "Page2";
      }
      return PartialView(vue);
    }

    [HttpGet]
    public ViewResult Action05Get()
    {
      ViewModel05 modèle = new ViewModel05();
      modèle.HeureChargement = DateTime.Now.ToString("hh:mm:ss");
      return View(modèle);
    }

    [HttpPost]
    public PartialViewResult Action05FaireCalcul(FormCollection postedData, SessionModel session)
    {
      // une exception artificielle pour tester la fonction d'erreur de l'appel Ajax
      //throw new Exception();
      // validation modèle
      ViewModel05 modèle = new ViewModel05();
      // l'heure de calcul
      modèle.HeureCalcul = DateTime.Now.ToString("hh:mm:ss");
      // mise à jour du modèle
      TryUpdateModel(modèle, postedData);
      if (!ModelState.IsValid)
      {
        // on retourne une erreur
        modèle.Erreurs = getListOfMessagesFor(ModelState);
        return PartialView("Failure05", modèle);
      }
      // on met les valeurs de A et B en session
      session.A = modèle.A;
      session.B = modèle.B;
      // pas d'erreurs pour l'instant
      List<string> erreurs = new List<string>();
      // une fois sur deux, on simule une erreur
      int val = session.Randomizer.Next(2);
      if (val == 0)
      {
        erreurs.Add("[erreur aléatoire]");
      }
      if (erreurs.Count != 0)
      {
        modèle.Erreurs = erreurs;
        return PartialView("Failure05", modèle);
      }
      // calculs
      double A = double.Parse(modèle.A);
      double B = double.Parse(modèle.B);
      modèle.AplusB = string.Format("{0}", A + B);
      modèle.AmoinsB = string.Format("{0}", A - B);
      modèle.AmultipliéparB = string.Format("{0}", A * B);
      modèle.AdiviséparB = string.Format("{0}", A / B);
      // vue
      return PartialView("Success05", modèle);
    }

    [HttpPost]
    public PartialViewResult Action05RetourSaisies(SessionModel session)
    {
      // vue
      return PartialView("Formulaire05", new ViewModel05() { A = session.A, B = session.B });
    }

    // ---------------------------------- helpers
    // ensemble des messages d'erreur sous forme de chaîne unique
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

    // ensemble des messages d'erreur sous forme deliste de chaînes
    private List<string> getListOfMessagesFor(ModelStateDictionary état)
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
      }
      return erreurs;
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
