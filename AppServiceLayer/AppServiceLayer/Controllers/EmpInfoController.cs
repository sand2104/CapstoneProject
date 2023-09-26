using BlogTracker.Data;
using BlogTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppServiceLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpInfoController : ControllerBase
    {
        private readonly BlogTrackerDbContext _dbContext;

        public EmpInfoController(BlogTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/EmpInfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpInfo>>> GetEmpInfo()
        {
            return await _dbContext.EmpInfo.ToListAsync();
        }

        // GET: api/EmpInfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpInfo>> GetEmpInfo(int id)
        {
            var empInfo = await _dbContext.EmpInfo.FindAsync(id);

            if (empInfo == null)
            {
                return NotFound();
            }

            return empInfo;
        }

        // POST: api/EmpInfo
        [HttpPost]
        public async Task<ActionResult<EmpInfo>> PostEmpInfo(EmpInfo empInfo)
        {
            _dbContext.EmpInfo.Add(empInfo);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetEmpInfo", new { id = empInfo.EmpInfoId }, empInfo);
        }

        // PUT: api/EmpInfo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpInfo(int id, EmpInfo empInfo)
        {
            if (id != empInfo.EmpInfoId)
            {
                return BadRequest();
            }

            _dbContext.Entry(empInfo).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpInfoExists(id))
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

        // DELETE: api/EmpInfo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpInfo(int id)
        {
            var empInfo = await _dbContext.EmpInfo.FindAsync(id);
            if (empInfo == null)
            {
                return NotFound();
            }

            _dbContext.EmpInfo.Remove(empInfo);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpInfoExists(int id)
        {
            return _dbContext.EmpInfo.Any(e => e.EmpInfoId == id);
        }
    }
}
