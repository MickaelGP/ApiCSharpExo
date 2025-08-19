using ExoTodo.Models;

namespace ExoTodo.Interfaces
{
    public interface ICrudTaches
    {
        public List<Taches> GetAllTaskByUserId(int utilId);

        public Taches GetTaskById(int unId);

        public int UpdateTask(Taches uneTache);

        public int DeleteTask(int unId);

        public int InsertTask(Taches uneTache);
    }
}
