using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookStoreAPI.Models;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        [HttpPost("")]
        public IActionResult AddBook([FromBody] BookModel model)
        {
            return Ok($"Book Id = {model.Title}");
        }


        [HttpGet("{name}")]
        public IActionResult GetBook([FromQuery] string name)
        {
            return Ok($"Name = {name}");
        }

       
    }
}
