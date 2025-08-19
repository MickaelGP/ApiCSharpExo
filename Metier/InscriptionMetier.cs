using ExoTodo.Models;
using ExoTodo.Repository;

namespace ExoTodo.Metier
{
    public class InscriptionMetier
    {
        private InscriptionRepo _repo = new InscriptionRepo();

        public bool AddNewUser(Utilisateurs unCompte)
        {
            int resultat = _repo.AddNewUser(unCompte);
            bool reponse;

            if (resultat > 0)
            {
                reponse = true;
            }
            else
            {
                reponse = false;
            }

            return reponse;
        }
    }
}
