using System.ComponentModel.DataAnnotations;

namespace Exemple_02.Models
{
  public class ActionModel04
  {
    [Required(ErrorMessage="Le paramètre url est requis")]
    [Url(ErrorMessage="URL invalide")]
    public string Url { get; set; }
    [Required(ErrorMessage = "Le paramètre info1 est requis")]
    public string Info1 { get; set; }
    [Required(ErrorMessage = "Le paramètre info2 est requis")]
    [Compare("Info1",ErrorMessage="Les paramètres info1 et info2 doivent être identiques")]
    public string Info2 { get; set; }
    [Required(ErrorMessage = "Le paramètre cc est requis")]
    [CreditCard(ErrorMessage = "Le paramètre cc n'est pas un n° de carte de crédit valide")]
    public string Cc { get; set; }
  }
}