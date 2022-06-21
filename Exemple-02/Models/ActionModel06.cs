using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Exemple_02.Models
{
  [Bind(Exclude = "info2")]
  public class ActionModel06
  {
    [Required(ErrorMessage = "Le paramètre [info1] est requis")]
    public string Info1 { get; set; }

    public string Info2 { get; set; }
  }
}