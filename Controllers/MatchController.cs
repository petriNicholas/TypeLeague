using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TypeLeague.Models;

namespace TypeLeague.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly TypeLeagueContext _context;

        public MatchController(TypeLeagueContext context)
        {
            _context = context;
        }

        // GET: api/Match
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatchModel>>> GetMatchModel()
        {
          if (_context.MatchModel == null)
          {
              return NotFound();
          }
            return await _context.MatchModel.ToListAsync();
        }

        // GET: api/Match/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MatchModel>> GetMatchModel(int id)
        {
          if (_context.MatchModel == null)
          {
              return NotFound();
          }
            var matchModel = await _context.MatchModel.FindAsync(id);

            if (matchModel == null)
            {
                return NotFound();
            }

            return matchModel;
        }

        // PUT: api/Match/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatchModel(int id, MatchModel matchModel)
        {
            if (id != matchModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(matchModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchModelExists(id))
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

        // POST: api/Match
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MatchModel>> PostMatchModel(MatchModel matchModel)
        {
          if (_context.MatchModel == null)
          {
              return Problem("Entity set 'TypeLeagueContext.MatchModel'  is null.");
          }
            _context.MatchModel.Add(matchModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMatchModel", new { id = matchModel.Id }, matchModel);
        }

        // DELETE: api/Match/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatchModel(int id)
        {
            if (_context.MatchModel == null)
            {
                return NotFound();
            }
            var matchModel = await _context.MatchModel.FindAsync(id);
            if (matchModel == null)
            {
                return NotFound();
            }

            _context.MatchModel.Remove(matchModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MatchModelExists(int id)
        {
            return (_context.MatchModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
