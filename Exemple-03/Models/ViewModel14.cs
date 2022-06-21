using Exemple_03.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Net.Mail;

namespace Exemple_03.Models
{
  public class ViewModel14 : IValidatableObject
  {

    [Required(ErrorMessageResourceType = typeof(MyResources), ErrorMessageResourceName = "infoRequise")]
    [Display(ResourceType = typeof(MyResources), Name = "chaineaumoins4")]
    [RegularExpression(@"^.{4,}$", ErrorMessageResourceType = typeof(MyResources), ErrorMessageResourceName = "infoIncorrecte")]
    public string Chaine1 { get; set; }

    [Display(ResourceType = typeof(MyResources), Name = "chaineauplus4")]
    [Required(ErrorMessageResourceType = typeof(MyResources), ErrorMessageResourceName = "infoRequise")]
    [RegularExpression(@"^.{1,4}$", ErrorMessageResourceType = typeof(MyResources), ErrorMessageResourceName = "infoIncorrecte")]
    public string Chaine2 { get; set; }

    [Required(ErrorMessageResourceType = typeof(MyResources), ErrorMessageResourceName = "infoRequise")]
    [Display(ResourceType = typeof(MyResources), Name = "chaine4exactement")]
    [RegularExpression(@"^.{4,4}$", ErrorMessageResourceType = typeof(MyResources), ErrorMessageResourceName = "infoIncorrecte")]
    public string Chaine3 { get; set; }

    [Required(ErrorMessageResourceType = typeof(MyResources), ErrorMessageResourceName = "infoRequise")]
    [Display(ResourceType = typeof(MyResources), Name = "entier")]
    public int Entier1 { get; set; }

    [Display(ResourceType = typeof(MyResources), Name = "entierentrebornes")]
    [Required(ErrorMessageResourceType = typeof(MyResources), ErrorMessageResourceName = "infoRequise")]
    [Range(1, 100, ErrorMessageResourceType = typeof(MyResources), ErrorMessageResourceName = "infoIncorrecte")]
    public int Entier2 { get; set; }

    [Display(ResourceType = typeof(MyResources), Name = "reel")]
    [Required(ErrorMessageResourceType = typeof(MyResources), ErrorMessageResourceName = "infoRequise")]
    public double Reel1 { get; set; }

    [Display(ResourceType = typeof(MyResources), Name = "reelentrebornes")]
    [Required(ErrorMessageResourceType = typeof(MyResources), ErrorMessageResourceName = "infoRequise")]
    [Range(10.2, 11.3, ErrorMessageResourceType = typeof(MyResources), ErrorMessageResourceName = "infoIncorrecte")]
    public double Reel2 { get; set; }

    [Display(ResourceType = typeof(MyResources), Name = "email")]
    [Required(ErrorMessageResourceType = typeof(MyResources), ErrorMessageResourceName = "infoRequise")]
    [EmailAddress(ErrorMessageResourceType = typeof(MyResources), ErrorMessageResourceName = "infoIncorrecte", ErrorMessage="")]
    public string Email1 { get; set; }

    [Display(ResourceType = typeof(MyResources), Name = "date1")]
    [RegularExpression(@"\s*\d{2}/\d{2}/\d{4}\s*", ErrorMessageResourceType = typeof(MyResources), ErrorMessageResourceName = "infoIncorrecte")]
    [Required(ErrorMessageResourceType = typeof(MyResources), ErrorMessageResourceName = "infoRequise")]
    public string Regexp1 { get; set; }

    [Display(ResourceType = typeof(MyResources), Name = "date2")]
    [Required(ErrorMessageResourceType = typeof(MyResources), ErrorMessageResourceName = "infoRequise")]
    [DataType(DataType.Date)]
    public DateTime Date1 { get; set; }

    // validation
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
      // liste des erreurs
      List<ValidationResult> résultats = new List<ValidationResult>();
      // le même msg d'erreur pour tous
      string errorMessage=MyResources.ResourceManager.GetObject("infoIncorrecte", new CultureInfo(System.Web.HttpContext.Current.Session["lang"] as string)).ToString();

      // Date 1
      if (Date1.Date <= DateTime.Now.Date)
      {
        résultats.Add(new ValidationResult(errorMessage, new string[] { "Date1" }));
      }
      // Email1
      try
      {
        new MailAddress(Email1);
      }
      catch
      {
        résultats.Add(new ValidationResult(errorMessage, new string[] { "Email1" }));
      }
      // Regexp1
      try
      {
        DateTime.ParseExact(Regexp1, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("fr-FR"));
      }
      catch
      {
        résultats.Add(new ValidationResult(errorMessage, new string[] { "Regexp1" }));
      }

      // on rend la liste des erreurs
      return résultats;
    }
  }
}