using Microsoft.Data.SqlClient;
using ExoTodo.Config;
namespace ExoTodo
{
    public class Connexion
    {
        private string ConnexionString = new Settings().GetDbString();

        public SqlConnection GetConnection()
        {
            SqlConnection connexion = new SqlConnection(ConnexionString);

            connexion.Open();

            return connexion;
        }
    }
}
