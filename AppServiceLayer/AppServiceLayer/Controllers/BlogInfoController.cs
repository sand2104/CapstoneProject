using BlogTracker.Data;
using BlogTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppServiceLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogInfoController : ControllerBase
    {
        private readonly BlogTrackerDbContext _dbContext;

        public BlogInfoController(BlogTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/BlogInfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogInfo>>> GetBlogInfo()
        {
            return await _dbContext.BlogInfo.ToListAsync();
        }

        // GET: api/BlogInfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogInfo>> GetBlogInfo(int id)
        {
            var blogInfo = await _dbContext.BlogInfo.FindAsync(id);

            if (blogInfo == null)
            {
                return NotFound();
            }

            return blogInfo;
        }

        // POST: api/BlogInfo
        [HttpPost]
        public async Task<ActionResult<BlogInfo>> PostBlogInfo(BlogInfo blogInfo)
        {
            _dbContext.BlogInfo.Add(blogInfo);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetBlogInfo", new { id = blogInfo.BlogInfoId }, blogInfo);
        }

        // PUT: api/BlogInfo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlogInfo(int id, BlogInfo blogInfo)
        {
            if (id != blogInfo.BlogInfoId)
            {
                return BadRequest();
            }

            _dbContext.Entry(blogInfo).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogInfoExists(id))
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

        // DELETE: api/BlogInfo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogInfo(int id)
        {
            var blogInfo = await _dbContext.BlogInfo.FindAsync(id);
            if (blogInfo == null)
            {
                return NotFound();
            }

            _dbContext.BlogInfo.Remove(blogInfo);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool BlogInfoExists(int id)
        {
            return _dbContext.BlogInfo.Any(e => e.BlogInfoId == id);
        }
    }
}
