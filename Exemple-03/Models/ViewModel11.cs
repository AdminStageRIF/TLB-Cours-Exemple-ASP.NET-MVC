using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Net.Mail;

namespace Exemple_03.Models
{
  public class ViewModel11 : IValidatableObject
  {

    [Required(ErrorMessage = "Information requise")]
    [Display(Name = "Chaîne d'au moins quatre caractères")]
    [RegularExpression(@"^.{4,}$", ErrorMessage = "Information incorrecte")]
    public string Chaine1 { get; set; }

    [Display(Name = "Chaîne d'au plus quatre caractères")]
    [Required(ErrorMessage = "Information requise")]
    [RegularExpression(@"^.{1,4}$", ErrorMessage = "Information incorrecte")]
    public string Chaine2 { get; set; }

    [Required(ErrorMessage = "Information requise")]
    [Display(Name = "Chaîne de quatre caractères exactement")]
    [RegularExpression(@"^.{4,4}$", ErrorMessage = "Information incorrecte")]
    public string Chaine3 { get; set; }

    [Required(ErrorMessage = "Information requise")]
    [Display(Name = "Nombre entier")]
    public int Entier1 { get; set; }

    [Display(Name = "Nombre entier dans l'intervalle [1,100]")]
    [Required(ErrorMessage = "Information requise")]
    [Range(1, 100, ErrorMessage = "Information incorrecte")]
    public int Entier2 { get; set; }

    [Display(Name = "Nombre réel")]
    [Required(ErrorMessage = "Information requise")]
    public double Reel1 { get; set; }

    [Display(Name = "Nombre réel dans l'intervalle [10.2, 11.3]")]
    [Required(ErrorMessage = "Information requise")]
    [Range(10.2, 11.3, ErrorMessage = "Information incorrecte")]
    public double Reel2 { get; set; }

    [Display(Name = "Adresse mail")]
    [Required(ErrorMessage = "Information requise")]
    [DataType(DataType.EmailAddress, ErrorMessage = "Information incorrecte")]
    public string Email1 { get; set; }

    [Display(Name = "Date sous la forme dd/jj/aaaa")]
    [RegularExpression(@"\s*\d{2}/\d{2}/\d{4}\s*", ErrorMessage = "Information incorrecte")]
    [Required(ErrorMessage = "Information requise")]
    public string Regexp1 { get; set; }

    [Display(Name = "Date postérieure à celle d'aujourd'hui")]
    [Required(ErrorMessage = "Information requise")]
    [DataType(DataType.Date)]
    public DateTime Date1 { get; set; }

    // validation
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
      List<ValidationResult> résultats = new List<ValidationResult>();
      // Date 1
      if (Date1.Date <= DateTime.Now.Date)
      {
        résultats.Add(new ValidationResult("Information incorrecte", new string[] { "Date1" }));
      }
      // Email1
      try
      {
        new MailAddress(Email1);
      }
      catch
      {
        résultats.Add(new ValidationResult("Information incorrecte", new string[] { "Email1" }));
      }
      // Regexp1
      try
      {
        DateTime.ParseExact(Regexp1, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("fr-FR"));
      }
      catch
      {
        résultats.Add(new ValidationResult("Information incorrecte", new string[] { "Regexp1" }));
      }

      // on rend la liste des erreurs
      return résultats;
    }
  }
}