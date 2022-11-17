using Microsoft.AspNetCore.Mvc;
using TaskManagerWebApi.Interface;
using TaskManagerWebApi.Repository;

namespace TaskManagerWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserObjectRepository _userObjectRepository;
        private readonly ILogger<UserController> _logger;
        public UserController(ILogger<UserController> logger,UserObjectRepository userObject) 
        {
            _logger = logger;
            _userObjectRepository = userObject;
        }
        [HttpGet("AllUsers")]
        public List<User> GetUser()
        {
            return _userObjectRepository.GetUsersList();
        }
    }
}
