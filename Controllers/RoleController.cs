using Microsoft.AspNetCore.Mvc;
using System.Data;
using TaskManagerWebApi.Repository;

namespace TaskManagerWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RoleController : Controller
    {
        private RoleRepository _roleRepository;
        public RoleController(RoleRepository RoleRepository)
        {
            _roleRepository = RoleRepository;
        }
        [HttpGet("AllRole")]
        public List<Role> GetRole()
        {
            return _roleRepository.GetList();
        }
        [HttpGet("FindRoleByID")]
        public Role GetProjectByID(int id)
        {
            return _roleRepository.GetByID(id);
        }
        [HttpPost("CreateProject")]
        public IActionResult Create(Role role)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _roleRepository.Create(role);
                    _roleRepository.Save();
                    return Ok(role);
                }
            }
            catch (DataException de)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
                return BadRequest(de.Message);
            }
            return Ok(role);
        }
        [HttpPost("EditRole")]
        public IActionResult Edit(Role role)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _roleRepository.Update(role);
                    _roleRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException dex)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
                return BadRequest(dex.Message);
            }
            return Ok(role);
        }
        [HttpPost("DeleteRole")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Role Role = _roleRepository.GetByID(id);
                _roleRepository.Delete(id);
                _roleRepository.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            _roleRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
