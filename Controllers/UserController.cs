using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TypeLeague.Models;
using TypeLeague.Models.UserModels;


namespace TypeLeague.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly TypeLeagueContext _context;

        public UserController(TypeLeagueContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserGetDTO>>> GetUsers()
        {
            return await _context.Users
                .Select( x => userToGetDTO(x))
                .ToListAsync();
        }


        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserGetDTO>> GetUser(int id)
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return userToGetDTO(user);
        }

        // PUT: api/User/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchUser(int id, UserPatchDTO userPutDTO)
        {

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            if (userPutDTO.Name!=null)
            {
                user.Name = userPutDTO.Name;
            }
            if (userPutDTO.Email!=null)
            {
                user.Email = userPutDTO.Email;
            }
            if (userPutDTO.Password != null)
            {
                user.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(userPutDTO.Password, 12);
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!userExists(id))
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

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<UserPostDTO>> PostUser(UserPostDTO userAddDTO)
        {
            var user = new User
            {
                Email = userAddDTO.Email,
                Name = userAddDTO.Name,
                Password = BCrypt.Net.BCrypt.EnhancedHashPassword(userAddDTO.Password, 12)
            };
            if (_context.Users == null)
            {
                return Problem("Entity set 'TypeLeagueContext.Users'  is null.");
            }
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetUser),
                new { id = user.UserId },
                userToGetDTO(user));
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool userExists(int id)
        {
            return (_context.Users?.Any(e => e.UserId == id)).GetValueOrDefault();
        }

        //Transforms the user resource into a format devoid of sensitive information,
        //only containing fields that should be returned to a Get request.
        private static UserGetDTO userToGetDTO(User user) =>
            new UserGetDTO
            {
                Id = user.UserId,
                Email = user.Email,
                Name = user.Name,
                Points = user.Points
            };

    }
}
