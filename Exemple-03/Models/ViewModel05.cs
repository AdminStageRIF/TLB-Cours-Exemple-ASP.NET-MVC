namespace Exemple_03.Models
{
  public class ViewModel05
  {
    public Personne2[] Personnes { get; set; }
    public int SelectedId { get; set; }

    public ViewModel05()
    {
      Personnes = new Personne2[] { 
        new Personne2 { Id = 1, Prénom = "Pierre", Nom = "Martino" }, 
        new Personne2 { Id = 2, Prénom = "Pauline", Nom = "Pereiro" }, 
        new Personne2 { Id = 3, Prénom = "Jacques", Nom = "Alfonso" } };
      SelectedId = 2;
    }
  }

  public class Personne2
  {
    public int Id { get; set; }
    public string Nom { get; set; }
    public string Prénom { get; set; }
  }
}