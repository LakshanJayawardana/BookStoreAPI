using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/users
        [HttpGet]
        public IActionResult GetUsers()
        {
            // Logic to get users
            return Ok(new { message = "List of users" });
        }
        // GET: api/users/{id}
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            // Logic to get a user by id
            return Ok(new { message = $"User with ID {id}" });
        }
        // POST: api/users
        [HttpPost]
        public IActionResult CreateUser([FromBody] object user)
        {
            // Logic to create a new user
            return CreatedAtAction(nameof(GetUser), new { id = 1 }, user);
        }
        // PUT: api/users/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] object user)
        {
            // Logic to update a user
            return NoContent();
        }
        // DELETE: api/users/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            // Logic to delete a user
            return NoContent();
        }
    }
}
