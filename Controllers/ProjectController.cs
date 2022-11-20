using Microsoft.AspNetCore.Mvc;
using System.Data;
using TaskManagerWebApi.Interface;
using TaskManagerWebApi.Repository;

namespace TaskManagerWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProjectController : Controller
    {
        private ProjectRepository _projectRepository ;
        public ProjectController(ProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        [HttpGet("AllProject")]
        public List<Project> GetProject()
        {
            return _projectRepository.GetList();
        }
        [HttpGet("FindProjectByID")]
        public Project GetProjectByID(int id)
        {
            return _projectRepository.GetByID(id);
        }
        [HttpPost("CreateProject")]
        public IActionResult Create(Project project)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _projectRepository.Create(project);
                    _projectRepository.Save();
                    return Ok(project);
                }
            }
            catch (DataException de)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
                return BadRequest(de.Message);
            }
            return Ok(project);
        }
        [HttpPost("EditProject")]
        public IActionResult Edit(Project project)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _projectRepository.Update(project);
                    _projectRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException dex)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
                return BadRequest(dex.Message);
            }
            return Ok(project);
        }
        [HttpPost("DeleteUser")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Project project = _projectRepository.GetByID(id);
                _projectRepository.Delete(id);
                _projectRepository.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            _projectRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
