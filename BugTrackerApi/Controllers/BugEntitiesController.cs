using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BugTrackerApi.Models;

namespace BugTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BugEntitiesController : ControllerBase
    {
        private readonly BugEntityContext _context;

        public BugEntitiesController(BugEntityContext context)
        {
            _context = context;
        }

        // GET: api/BugEntities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BugEntity>>> GetBugEntities()
        {
          if (_context.BugEntities == null)
          {
              return NotFound();
          }
            return await _context.BugEntities.ToListAsync();
        }

        // GET: api/BugEntities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BugEntity>> GetBugEntity(int id)
        {
          if (_context.BugEntities == null)
          {
              return NotFound();
          }
            var bugEntity = await _context.BugEntities.FindAsync(id);

            if (bugEntity == null)
            {
                return NotFound();
            }

            return bugEntity;
        }

        // PUT: api/BugEntities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBugEntity(int id, BugEntity bugEntity)
        {
            if (id != bugEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(bugEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BugEntityExists(id))
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

        // POST: api/BugEntities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BugEntity>> PostBugEntity(BugEntity bugEntity)
        {
            _context.BugEntities.Add(bugEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBugEntity", new { id = bugEntity.Id }, bugEntity);
        }

        // DELETE: api/BugEntities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBugEntity(int id)
        {
            if (_context.BugEntities == null)
            {
                return NotFound();
            }
            var bugEntity = await _context.BugEntities.FindAsync(id);
            if (bugEntity == null)
            {
                return NotFound();
            }

            _context.BugEntities.Remove(bugEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BugEntityExists(int id)
        {
            return (_context.BugEntities?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
