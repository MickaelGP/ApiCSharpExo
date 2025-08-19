using ExoTodo.Metier;
using ExoTodo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace ExoTodo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TachesController : ControllerBase
    {
        private TacheMetier _metier = new TacheMetier();

        [HttpGet("/list-task/{unId}")]
        public IActionResult GetAllTaskByUserId(int unId)
        {
            List<Taches> listTasks = _metier.GetAllTaskByUserId(unId);

            return Ok(listTasks);
        }

        [HttpGet("/task/{unId}")]
        public IActionResult GetTaskById(int unId)
        {
            Taches Task = _metier.GetTaskById(unId);
            if(Task == null)
            {
                return StatusCode(404, new ProblemDetails
                {
                    Title = "Aucune tâche trouvée",
                    Detail = "Cette tâche n'existe pas !",
                    Status = StatusCodes.Status404NotFound
                });
            }
            return Ok(Task);
        }
        [HttpPost("/add-task")]
        public IActionResult CreateTask( [FromForm]string unNom, [FromForm] int unUtilId)
        {
            Taches newTask = new Taches(unNom, unUtilId);

            int resultat = _metier.InsertTask(newTask);
            if(resultat == 0)
            {
                return StatusCode(500, new ProblemDetails
                {
                    Title = "Erreur lors de la création",
                    Detail = "Une erreur s'est produite lors de la création de la tâche !",
                    Status = StatusCodes.Status500InternalServerError
                });
            }

            return Ok();
        }

        [HttpDelete("/delete-task")]
        public IActionResult DeleteTask([FromBody] int unId)
        {
            int resultat = _metier.DeleteTask(unId);

            if(resultat == 0)
            {
                return StatusCode(500, new ProblemDetails
                {
                    Title = "Erreur lors de suppression",
                    Detail = "Une erreur s'est produite lors de la suppression de la tâche !",
                    Status = StatusCodes.Status500InternalServerError
                });
            }

            return NoContent();
        }

        [HttpPut("/update-task")]
        public IActionResult UpdateTodo([FromBody] Taches task)
        {
            int resultat = _metier.UpdateTask(task);

            if(resultat == 0)
            {
                return StatusCode(500, new ProblemDetails
                {
                    Title = "Erreur lors de suppression",
                    Detail = "Une erreur s'est produite lors de la suppression de la tâche !",
                    Status = StatusCodes.Status500InternalServerError
                });
            }

            return NoContent();
        }
    }
}
