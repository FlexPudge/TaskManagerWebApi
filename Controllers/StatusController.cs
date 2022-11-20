using Microsoft.AspNetCore.Mvc;
using System.Data;
using TaskManagerWebApi.Repository;

namespace TaskManagerWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StatusController : Controller
    {
        private StatusRepository _statusRepository;
        public StatusController(StatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }
        [HttpGet("AllStatus")]
        public List<Status> GetStatus()
        {
            return _statusRepository.GetList();
        }
        [HttpGet("FindStatusByID")]
        public Status GetProjectByID(int id)
        {
            return _statusRepository.GetByID(id);
        }
        [HttpPost("CreateProject")]
        public IActionResult Create(Status status)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _statusRepository.Create(status);
                    _statusRepository.Save();
                    return Ok(status);
                }
            }
            catch (DataException de)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
                return BadRequest(de.Message);
            }
            return Ok(status);
        }
        [HttpPost("EditStatus")]
        public IActionResult Edit(Status status)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _statusRepository.Update(status);
                    _statusRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException dex)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
                return BadRequest(dex.Message);
            }
            return Ok(status);
        }
        [HttpPost("DeleteStatus")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Status Status = _statusRepository.GetByID(id);
                _statusRepository.Delete(id);
                _statusRepository.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            _statusRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
