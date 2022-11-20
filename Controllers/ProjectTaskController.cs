using Microsoft.AspNetCore.Mvc;
using System.Data;
using TaskManagerWebApi.Repository;

namespace TaskManagerWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProjectTaskController : Controller
    {
        private ProjectTaskRepository _projectTaskRepository;
        public ProjectTaskController(ProjectTaskRepository projectTaskRepository)
        {
            _projectTaskRepository = projectTaskRepository;
        }
        [HttpGet("AllProjectTask")]
        public List<ProjectTask> GetProjectTask()
        {
            return _projectTaskRepository.GetList();
        }
        [HttpGet("FindProjectTaskByID")]
        public ProjectTask GetProjectByID(int id)
        {
            return _projectTaskRepository.GetByID(id);
        }
        [HttpPost("CreateProject")]
        public IActionResult Create(ProjectTask projectTask)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _projectTaskRepository.Create(projectTask);
                    _projectTaskRepository.Save();
                    return Ok(projectTask);
                }
            }
            catch (DataException de)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
                return BadRequest(de.Message);
            }
            return Ok(projectTask);
        }
        [HttpPost("EditProjectTask")]
        public IActionResult Edit(ProjectTask projectTask)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _projectTaskRepository.Update(projectTask);
                    _projectTaskRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException dex)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
                return BadRequest(dex.Message);
            }
            return Ok(projectTask);
        }
        [HttpPost("DeleteProjectTask")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                ProjectTask projectTask = _projectTaskRepository.GetByID(id);
                _projectTaskRepository.Delete(id);
                _projectTaskRepository.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            _projectTaskRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
