
namespace Exemple_03.Models
{
  public class ApplicationModel
  {
    // les collections à afficher dans le formulaire
    public Item[] RadioButtonFieldItems { get; set; }
    public Item[] CheckBoxesFieldItems { get; set; }
    public Item[] DropDownListFieldItems { get; set; }
    public Item[] SimpleChoiceListFieldItems { get; set; }
    public Item[] MultipleChoiceListFieldItems { get; set; }

    // initialisation des champs et collections
    public ApplicationModel()
    {
      RadioButtonFieldItems = new Item[]{
        new Item {Value="1",Label="oui"},
        new Item {Value="2", Label="non"}
      };
      CheckBoxesFieldItems = new Item[]{
        new Item {Value="1",Label="1"},
        new Item {Value="2", Label="2"},
        new Item {Value="3", Label="3"}
      };
      DropDownListFieldItems = new Item[]{
        new Item {Value="1",Label="choix1"},
        new Item {Value="2", Label="choix2"},
        new Item {Value="3", Label="choix3"}
      };
      SimpleChoiceListFieldItems = new Item[]{
        new Item {Value="1",Label="liste1"},
        new Item {Value="2", Label="liste2"},
        new Item {Value="3", Label="liste3"},
        new Item {Value="4", Label="liste4"},
        new Item {Value="5", Label="liste5"}
      };
      MultipleChoiceListFieldItems = new Item[]{
        new Item {Value="1",Label="liste1"},
        new Item {Value="2", Label="liste2"},
        new Item {Value="3", Label="liste3"},
        new Item {Value="4", Label="liste4"},
        new Item {Value="5", Label="liste5"}
      };
    }
    // l'élément des collections
    public class Item
    {
      public string Label { get; set; }
      public string Value { get; set; }
    }

  }
}