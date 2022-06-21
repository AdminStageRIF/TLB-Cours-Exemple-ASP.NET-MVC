using System.ComponentModel.DataAnnotations;
namespace Exemple_03.Models
{
  public class ActionModel06
  {
    [Required(ErrorMessage = "Le paramètre personneId est requis")]
    public int PersonneId { get; set; }

    [Required(ErrorMessage = "Le paramètre valider est requis")]
    public string Valider { get; set; }
  }
}