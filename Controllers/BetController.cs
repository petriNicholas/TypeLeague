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
    public class BetController : ControllerBase
    {
        private readonly TypeLeagueContext _context;

        public BetController(TypeLeagueContext context)
        {
            _context = context;
        }

        // GET: api/Bet
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BetModel>>> GetBetModel()
        {
          if (_context.BetModel == null)
          {
              return NotFound();
          }
            return await _context.BetModel.ToListAsync();
        }

        // GET: api/Bet/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BetModel>> GetBetModel(int id)
        {
          if (_context.BetModel == null)
          {
              return NotFound();
          }
            var betModel = await _context.BetModel.FindAsync(id);

            if (betModel == null)
            {
                return NotFound();
            }

            return betModel;
        }

        // PUT: api/Bet/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBetModel(int id, BetModel betModel)
        {
            if (id != betModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(betModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BetModelExists(id))
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

        // POST: api/Bet
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BetModel>> PostBetModel(BetModel betModel)
        {
          if (_context.BetModel == null)
          {
              return Problem("Entity set 'TypeLeagueContext.BetModel'  is null.");
          }
            _context.BetModel.Add(betModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBetModel", new { id = betModel.Id }, betModel);
        }

        // DELETE: api/Bet/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBetModel(int id)
        {
            if (_context.BetModel == null)
            {
                return NotFound();
            }
            var betModel = await _context.BetModel.FindAsync(id);
            if (betModel == null)
            {
                return NotFound();
            }

            _context.BetModel.Remove(betModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BetModelExists(int id)
        {
            return (_context.BetModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
