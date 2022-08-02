using CCSA_Web.DTO;
using CCSA_Web.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace CCSA_Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public IUserService _userDb{ get; }
        public UserController(IUserService userDb)
        {
            _userDb = userDb;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_userDb.GetUsers());
        }
        
        [HttpGet("{id}")]
        public IActionResult GetUser(Guid id)
        {
            return Ok(_userDb.GetUser(id));
        }
        
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDTO user)
        {
            _userDb.CreateUser(user.Username, user.Email, user.Password);
            return Ok("User Created Successfully");
        }

        [HttpPut("update-email")]
        public IActionResult UpdateEmail(Guid id, string email)
        {
            _userDb.UpdateEmail(id, email);
            return Ok("Updated Successfully");
        }
        

        [HttpPut("update-name")]
        public IActionResult UpdateName(Guid id, string name)
        {
            _userDb.UpdateName(id, name);
            return Ok("Updated Successfully");
        }
        
        
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            _userDb.DeleteUser(id);
            return Ok("User Deleted Successfully");
        }
        
        
    }
}
