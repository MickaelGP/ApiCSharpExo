using ExoTodo.Metier;
using ExoTodo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExoTodo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscriptionController : ControllerBase
    {
        private InscriptionMetier _metier = new InscriptionMetier();

        [HttpPost]
        public IActionResult AddNewUser([FromBody] Utilisateurs unUtilisateur)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(unUtilisateur.UtilMdp, 12);

            unUtilisateur.UtilMdp = passwordHash;

            bool resultat = _metier.AddNewUser(unUtilisateur);

            if (!resultat)
            {
                return StatusCode(500, new ProblemDetails
                {
                    Title = "Erreur lors de la création",
                    Detail = "Une erreur s'est produite lors de la création du compte !",
                    Status = StatusCodes.Status500InternalServerError
                });
            }

            return Ok(new { message = "Inscription réussie" });
        }
    }
}
