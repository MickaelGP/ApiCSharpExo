namespace ExoTodo.Models
{
    public class Taches
    {
        public int TodoId { get; set; }

        public string TodoNom { get; set; }

        public bool TodoCompleter { get; set; }

        public int TodoUtil { get; set; }

        public Taches() { }

        public Taches(string unNom, int unUtilisateur )
        {
            this.TodoNom = unNom;
            this.TodoUtil = unUtilisateur;
        }
    }
}
