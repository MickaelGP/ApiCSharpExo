using ExoTodo.Interfaces;
using ExoTodo.Models;
using ExoTodo.Repository;

namespace ExoTodo.Metier
{
    public class TacheMetier : ICrudTaches
    {
        private TacheRepo _repo = new TacheRepo();

        private bool CompletedIsFalse = false;
        public int DeleteTask(int unId)
        {
            int resultat = _repo.DeleteTask(unId);

            return resultat;
        }

        public List<Taches> GetAllTaskByUserId(int utilId)
        {
           List<Taches> listeTaches = _repo.GetAllTaskByUserId(utilId);

            return listeTaches;
        }

        public Taches GetTaskById(int unId)
        {
            Taches uneTache = _repo.GetTaskById(unId);

            return uneTache;
        }

        public int InsertTask(Taches uneTache)
        {
            uneTache.TodoCompleter = this.CompletedIsFalse;

            int resultat = _repo.InsertTask(uneTache);

            return resultat;
        }

        public int UpdateTask(Taches uneTache)
        {
            int resultat = _repo.UpdateTask(uneTache);

            return resultat;
        }
    }
}
