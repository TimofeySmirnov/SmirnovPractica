using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationFindWorker.Models;
namespace WebApplicationFindWorker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly FindWorkerContext _context;

        public PostController(FindWorkerContext context)
        {
            _context = context;
        }
        // GET: api/post
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetAll()
        {
            return await _context.Posts.ToListAsync();
        }

        // GET: api/post/{id}
        [HttpGet("{Id}")]
        public async Task<ActionResult<Post>> GetById(int Id)
        {
            var posts = await _context.Posts.FindAsync(Id);
            if (posts is null)
                return NotFound();

            return posts;
        }

        // POST: api/post
        [HttpPost]
        public async Task<IActionResult> Create(Post post)
        {
            try
            {
                _context.Posts.Add(post);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetById), new { Id = post.Id }, post);
            }
            catch (DbUpdateException)
            {
                // Обработка исключения
                return BadRequest("Ошибка при создании должности.");
            }
        }

        // PUT: apipost/{id}
        [HttpPut("{Id}")]
        public async Task<IActionResult> PutPost(int Id, Post post)
        {
            if (Id != post.Id)
            {
                return BadRequest();
            }

            _context.Entry(post).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(Id))
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

        private bool PostExists(int Id)
        {
            return _context.Posts.Any(e => e.Id == Id);
        }

        // DELETE: api/post/{id}
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteOfffer(int Id)
        {
            var post = await _context.Posts.FindAsync(Id);
            if (post == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return NoContent();
        }
  
        
    }
}

