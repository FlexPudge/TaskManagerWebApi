using Microsoft.AspNetCore.Mvc;
using System.Data;
using TaskManagerWebApi.Interface;
using TaskManagerWebApi.Repository;

namespace TaskManagerWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        //dotnet ef migrations add CreateInitial
        //dotnet ef database update
        private UserRepository _userRepository;
        public UserController(UserRepository userObject)
        {
            _userRepository = userObject;
        }
        [HttpGet("AllUsers")]
        public List<User> GetUser()
        {
            return _userRepository.GetUsersList();
        }
        [HttpGet("FindUserByID")]
        public User GetUserByID(int id)
        {
            return _userRepository.GetUserByID(id);
        }
        [HttpPost("CreateUser")]
        public IActionResult Create(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userRepository.Create(user);
                    _userRepository.Save();
                    return Ok(user);
                }
            }
            catch (DataException de)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
                return BadRequest(de.Message);
            }
            return Ok(user);
        }
        [HttpPost("EditUser")]
        public IActionResult Edit(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userRepository.Update(user);
                    _userRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException dex)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
                return BadRequest(dex.Message);
            }
            return Ok(user);
        }
        [HttpPost("DeleteUser")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                User user = _userRepository.GetUserByID(id);
                _userRepository.Delete(id);
                _userRepository.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            _userRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
