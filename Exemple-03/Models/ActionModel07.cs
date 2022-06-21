using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace Exemple_03.Models
{
  public class ActionModel07
  {
    [Required(ErrorMessage = "Le paramètre personneId est requis")]
    public int PersonneId { get; set; }

    [Required(ErrorMessage = "Le paramètre valider est requis")]
    public string Valider { get; set; }
  }
}