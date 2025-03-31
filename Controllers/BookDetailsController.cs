using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStoreAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace BookStoreAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookDetailsController : ControllerBase
    {
        private readonly BookDetailsContext _context;

        public BookDetailsController(BookDetailsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDetail>>> GetBookDetails()
        {
            if(_context.BookDetails == null)
            {
                return NotFound();
            }
            var book = await _context.BookDetails.ToListAsync();
            return Ok(book);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<BookDetail>> GetBookDetail(int id)
        {
            var bookDetail = await _context.BookDetails.FindAsync(id);

            if (bookDetail == null)
            {
                return NotFound();
            }

            return bookDetail;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookDetail(int id, BookDetail bookDetail)
        {
            if (id != bookDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(bookDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<BookDetail>> PostBookDetail([FromBody]BookDetail bookDetail)
        {
            if(_context.BookDetails == null)
            {
                return Problem("Entity set is null");
            }
            _context.BookDetails.Add(bookDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookDetail", new { id = bookDetail.Id }, bookDetail);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookDetail(int id)
        {
            if(_context.BookDetails == null)
            {
                return NotFound();
            }
            var bookDetail = await _context.BookDetails.FindAsync(id);
            if (bookDetail == null)
            {
                return NotFound();
            }

            _context.BookDetails.Remove(bookDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookDetailExists(int id)
        {
            return _context.BookDetails.Any(e => e.Id == id);
        }
    }
}
