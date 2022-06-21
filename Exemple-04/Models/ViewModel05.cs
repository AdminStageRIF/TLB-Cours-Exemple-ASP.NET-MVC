using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Exemple_04.Models
{
  [Bind(Exclude = "AplusB, AmoinsB, AmultipliéparB, AdiviséparB, Erreurs, HeureChargement, HeureCalcul")]
  public class ViewModel05
  {
    // formulaire
    [Required(ErrorMessage="Donnée A requise")]
    [Display(Name="Valeur de A")]
    [Range(0, Double.MaxValue, ErrorMessage = "Tapez un nombre A positif ou nul")]
    public string A { get; set; }
    [Required(ErrorMessage = "Donnée B requise")]
    [Display(Name = "Valeur de B")]
    [Range(0, Double.MaxValue, ErrorMessage="Tapez un nombre B positif ou nul")]
    public string B { get; set; }

    // résultats
    public string AplusB { get; set; }
    public string AmoinsB { get; set; }
    public string AmultipliéparB { get; set; }
    public string AdiviséparB { get; set; }
    public List<string> Erreurs { get; set; }
    public string HeureChargement { get; set; }
    public string HeureCalcul { get; set; }
  }
}