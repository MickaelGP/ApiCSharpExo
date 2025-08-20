using ExoTodo.Config;
using Microsoft.Data.SqlClient;
using System.Data;
namespace ExoTodo
{
    public abstract class Connexion
    {
        private readonly string ConnexionString;

        protected SqlConnection _connexion;

        public Connexion()
        {
            ConnexionString = new Settings().GetDbString();
        }

        protected void DbConnecter()
        {
            if (_connexion == null || _connexion.State == ConnectionState.Closed)
            {
                this.GetConnection();
            }
        }

        protected void DbDeconnecter()
        {
            if (_connexion == null || _connexion.State != ConnectionState.Closed)
            {
                this._connexion.Close();
            }
        }
        private void GetConnection()
        {
            this._connexion = new SqlConnection(this.ConnexionString);

            _connexion.Open();
        }
    }
}
