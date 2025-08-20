using ExoTodo.Interfaces;
using ExoTodo.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ExoTodo.Repository
{
    public class TacheRepo : Connexion, ICrudTaches
    {
        public int DeleteTask(int unId)
        {
            DbConnecter();

            SqlCommand cmd = _connexion.CreateCommand();

            cmd.CommandText = "DELETE FROM todos WHERE TodoId = @TodoId";

            SqlParameter TodoId = cmd.Parameters.Add("@TodoId", SqlDbType.Int);

            TodoId.Value = unId;

            int resultat = cmd.ExecuteNonQuery();

            DbConnecter() ;

            return resultat;
        }

        public List<Taches> GetAllTaskByUserId(int utilId)
        {
            DbConnecter();

            List<Taches> listeTaches = new List<Taches>();

            SqlCommand cmd = _connexion.CreateCommand();

            cmd.CommandText = "SELECT * FROM todos WHERE TodoUtil =@Id";

            SqlParameter Id = cmd.Parameters.Add("@Id", SqlDbType.Int);

            Id.Value = utilId;

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Taches taches = new Taches
                {
                    TodoId = (int)reader["TodoId"],
                    TodoNom = reader["TodoNom"].ToString(),
                    TodoCompleter = (bool)reader["TodoCompleter"]
                };
                listeTaches.Add(taches);
            }

            DbDeconnecter() ;

            return listeTaches;
        }

        public Taches GetTaskById(int unId)
        {
            DbConnecter();

            Taches unTodo = null;

            SqlCommand cmd = _connexion.CreateCommand();

            cmd.CommandText = "SELECT * FROM todos WHERE TodoId = @TodoId";

            SqlParameter TodoId = cmd.Parameters.Add("@TodoId", SqlDbType.Int);

            TodoId.Value = unId;

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                unTodo = new Taches
                {
                    TodoId = (int)reader["TodoId"],
                    TodoCompleter = (bool)reader["TodoCompleter"],
                    TodoNom = reader["TodoNom"].ToString()
                };
            }

            DbDeconnecter();

            return unTodo;
        }

        public int InsertTask(Taches uneTache)
        {
            DbConnecter();

            SqlCommand cmd = _connexion.CreateCommand();

            cmd.CommandText = "INSERT INTO todos (TodoNom, TodoCompleter, TodoUtil ) VALUES (@TodoNom, @TodoCompleter, @TodoUtil )";

            SqlParameter TodoNom = cmd.Parameters.Add("@TodoNom", SqlDbType.VarChar);
            SqlParameter TodoCompleter = cmd.Parameters.Add("@TodoCompleter", SqlDbType.Bit);
            SqlParameter TodoUtil = cmd.Parameters.Add("@TodoUtil", SqlDbType.Int);

            TodoNom.Value = uneTache.TodoNom;
            TodoCompleter.Value = uneTache.TodoCompleter;
            TodoUtil.Value = uneTache.TodoUtil;

            int resultat = cmd.ExecuteNonQuery();

            DbDeconnecter();

            return resultat;
        }

        public int UpdateTask(Taches uneTache)
        {
            DbConnecter();

            SqlCommand cmd = _connexion.CreateCommand();

            cmd.CommandText = "UPDATE todos SET  TodoNom = @TodoNom, TodoCompleter = @TodoCompleter WHERE TodoId = @TodoId";

            SqlParameter TodoNom = cmd.Parameters.Add("@TodoNom", SqlDbType.VarChar);
            SqlParameter TodoCompleter = cmd.Parameters.Add("@TodoCompleter", SqlDbType.Bit);
            SqlParameter TodoId = cmd.Parameters.Add("@TodoId", SqlDbType.Int);

            TodoNom.Value = uneTache.TodoNom;
            TodoCompleter.Value = uneTache.TodoCompleter;
            TodoId.Value = uneTache.TodoId;

            int resultat = cmd.ExecuteNonQuery();

            DbDeconnecter();

            return resultat;
        }


    }
}
