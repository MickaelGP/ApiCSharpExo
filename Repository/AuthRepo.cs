using Microsoft.Data.SqlClient;

namespace ExoTodo.Repository
{
    public class AuthRepo
    {
        private SqlConnection _connexion;

        public AuthRepo()
        {
            DbConnecter();
        }

        private void DbConnecter()
        {
            Connexion maConnexion = new Connexion();
            _connexion = maConnexion.GetConnection();
        }
    }
}
