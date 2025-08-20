using ExoTodo.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ExoTodo.Repository
{
    public class InscriptionRepo : Connexion
    {
        public int AddNewUser(Utilisateurs unUtilisateur)
        {
            DbConnecter();

            SqlCommand cmd = _connexion.CreateCommand();

            cmd.CommandText = "INSERT INTO utilisateurs (UtilPseudo, UtilEmail, UtilMdp) VALUES (@UtilPseudo, @UtilEmail, @UtilMdp )";

            SqlParameter UtilPseudo = cmd.Parameters.Add("@UtilPseudo", SqlDbType.VarChar);
            SqlParameter UtilEmail = cmd.Parameters.Add("@UtilEmail", SqlDbType.VarChar);
            SqlParameter UtilMdp = cmd.Parameters.Add("@UtilMdp", SqlDbType.VarChar);

            UtilPseudo.Value = unUtilisateur.UtilPseudo;
            UtilEmail.Value = unUtilisateur.UtilEmail;
            UtilMdp.Value = unUtilisateur.UtilMdp;

            int resultat = cmd.ExecuteNonQuery();

            DbDeconnecter();

            return resultat;
        }
    }
}
