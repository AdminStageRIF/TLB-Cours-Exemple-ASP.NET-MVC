using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Exemple_04.Models
{
  [Bind(Exclude = "AplusB, AmoinsB, AmultipliéparB, AdiviséparB, Erreur, HeureChargement, HeureCalcul")]
  public class ViewModel01
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
    public string AplusB { get; set; }
    public string AmoinsB { get; set; }
    public string AmultipliéparB { get; set; }
    public string AdiviséparB { get; set; }
    public string Erreur { get; set; }
    public string HeureChargement { get; set; }
    public string HeureCalcul { get; set; }
  }
}