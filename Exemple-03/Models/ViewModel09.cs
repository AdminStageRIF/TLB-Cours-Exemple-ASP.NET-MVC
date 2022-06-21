using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Exemple_03.Models;

namespace Exemple_03.Models
{
  public class ViewModel09
  {
    // les champs de saisie
    public string RadioButtonField { get; set; }
    public bool CheckBoxField1 { get; set; }
    public bool CheckBoxField2 { get; set; }
    public bool CheckBoxField3 { get; set; }
    public string TextField { get; set; }
    public string PasswordField { get; set; }
    public string TextAreaField { get; set; }
    public string DropDownListField { get; set; }
    public string SimpleChoiceListField { get; set; }
    public string[] MultipleChoiceListField { get; set; }

    // les collections à afficher dans le formulaire
    public ApplicationModel.Item[] RadioButtonFieldItems { get; set; }
    public ApplicationModel.Item[] CheckBoxesFieldItems { get; set; }
    public ApplicationModel.Item[] DropDownListFieldItems { get; set; }
    public ApplicationModel.Item[] SimpleChoiceListFieldItems { get; set; }
    public ApplicationModel.Item[] MultipleChoiceListFieldItems { get; set; }

    // constructeurs
    public ViewModel09()
    {
    }

    public ViewModel09(ApplicationModel application)
    {
      // initialisation collections
      RadioButtonFieldItems = application.RadioButtonFieldItems;
      CheckBoxesFieldItems = application.CheckBoxesFieldItems;
      DropDownListFieldItems = application.DropDownListFieldItems;
      SimpleChoiceListFieldItems = application.SimpleChoiceListFieldItems;
      MultipleChoiceListFieldItems = application.MultipleChoiceListFieldItems;
      // initialisation champs
      RadioButtonField = "2";
      CheckBoxField2 = true;
      TextField = "quelques mots";
      PasswordField = "secret";
      TextAreaField = "ligne1\nligne2";
      DropDownListField = "2";
      SimpleChoiceListField = "3";
      MultipleChoiceListField = new string[] { "1", "3" };
    }
  }
}