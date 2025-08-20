using ExoTodo.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ExoTodo.Repository
{
    public class AuthRepo : Connexion
    {
        public Utilisateurs Connexion(string unEmail)
        {
            DbConnecter();


            SqlCommand cmd = _connexion.CreateCommand();

            cmd.CommandText = "SELECT UtilId, UtilEmail, UtilMdp FROM utilisateurs ";

            SqlParameter UtilEmail = cmd.Parameters.Add("@UtilEmail", SqlDbType.VarChar);

            UtilEmail.Value = unEmail;

            SqlDataReader reader = cmd.ExecuteReader();
            Utilisateurs? infoUtilisateur = null;
            while (reader.Read())
            {
                infoUtilisateur = new Utilisateurs
                {
                    UtilId = (int)reader["UtilId"],
                    UtilEmail = reader["UtilEmail"].ToString(),
                    UtilMdp = reader["UtilMdp"].ToString()
                };
            }
            reader.Close();

            DbDeconnecter();

            return infoUtilisateur;
        }

        public int CreateSession(Sessions unSession)
        {

            DbConnecter();


            SqlCommand cmd = _connexion.CreateCommand();

            cmd.CommandText = "INSERT INTO Sessions (SessionExpire, SessionToken, SessionUtil) VALUES (@SessionExpire, @SessionToken, @SessionUtil)";

            SqlParameter SessionExpire = cmd.Parameters.Add("@SessionExpire", SqlDbType.DateTime);
            SqlParameter SessionToken = cmd.Parameters.Add("@SessionToken", SqlDbType.NVarChar);
            SqlParameter SessionUtil = cmd.Parameters.Add("@SessionUtil", SqlDbType.Int);

            SessionExpire.Value = unSession.SessionExpire;
            SessionToken.Value = unSession.SessionToken;
            SessionUtil.Value = unSession.SessionUtil;

            int resultat = cmd.ExecuteNonQuery();

            this._connexion.Close();

            DbDeconnecter();

            return resultat;
        }
    }
}