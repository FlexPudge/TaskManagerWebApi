using Microsoft.AspNetCore.Mvc;
using System.Data;
using TaskManagerWebApi.Repository;
using Task = TaskManagerWebApi.Model.Task;

namespace TaskManagerWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaskController : Controller
    {
        private TaskRepository _taskRepository;
        public TaskController(TaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        [HttpGet("AllTask")]
        public List<Task> GetTask()
        {
            return _taskRepository.GetList();
        }
        [HttpGet("FindTaskByID")]
        public Task GetProjectByID(int id)
        {
            return _taskRepository.GetByID(id);
        }
        [HttpPost("CreateProject")]
        public IActionResult Create(Task task)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _taskRepository.Create(task);
                    _taskRepository.Save();
                    return Ok(task);
                }
            }
            catch (DataException de)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
                return BadRequest(de.Message);
            }
            return Ok(task);
        }
        [HttpPost("EditTask")]
        public IActionResult Edit(Task task)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _taskRepository.Update(task);
                    _taskRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException dex)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
                return BadRequest(dex.Message);
            }
            return Ok(task);
        }
        [HttpPost("DeleteTask")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Task task = _taskRepository.GetByID(id);
                _taskRepository.Delete(id);
                _taskRepository.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            _taskRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
