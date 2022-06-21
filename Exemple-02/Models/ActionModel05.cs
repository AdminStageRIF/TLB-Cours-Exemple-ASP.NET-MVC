using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Exemple_02.Models
{
  public class ActionModel05 : IValidatableObject
  {
    [Required(ErrorMessage = "Le paramètre taux est requis")]
    public double? Taux { get; set; }
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
      List<ValidationResult> résultats = new List<ValidationResult>();
      bool ok = Taux < 4.2 || Taux > 6.7;
      if (!ok)
      {
        résultats.Add(new ValidationResult("Le paramètre taux doit être < 4.2 ou > 6.7", new string[] { "Taux" }));
      }
      return résultats;
    }
  }
}