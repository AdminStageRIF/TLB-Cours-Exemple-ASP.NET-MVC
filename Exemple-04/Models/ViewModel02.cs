using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Exemple_04.Models
{
  [Bind(Exclude = "HeureChargement")]
  public class ViewModel02
  {
    // formulaire
    [Required(ErrorMessage="Donnée requise")]
    [Display(Name="Valeur de A")]
    [Range(0, Double.MaxValue, ErrorMessage = "Tapez un nombre positif ou nul")]
    public double A { get; set; }
    [Required(ErrorMessage = "Donnée requise")]
    [Display(Name = "Valeur de B")]
    [Range(0, Double.MaxValue, ErrorMessage="Tapez un nombre positif ou nul")]
    public double B { get; set; }
    // résultats
    public string HeureChargement { get; set; }
  }
}