using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TypeLeague.Models;
using TypeLeague.Models.UserModels;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace TypeLeague.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<TypeLeagueUser> _userManager;

        public UserController(UserManager<TypeLeagueUser> userManager)
        {
            _userManager = userManager;
        }

        // GET: api/user/all 
        [HttpGet("all")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<UserGetDTO>>> GetUsers()
        {
            return await _userManager.Users
                .Select( x => userToGetDTO(x))
                .ToListAsync();
        }


        // GET: api/user
        //Get data about the currently logged in user.
        [HttpGet]
        [Authorize(Roles = "user")]
        public async Task<ActionResult<UserGetDTO>> GetUser()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; //Gets the user ID from the JwtRegisteredClaimNames.Sub value in the JWT.
            if (_userManager.Users == null)
            {
                return NotFound();
            }
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            return userToGetDTO(user);
        }

        // POST: api/user
        [HttpPost]
        public async Task<ActionResult<UserAddDTO>> PostUser(UserAddDTO userAddDTO)
        {
            if (ModelState.IsValid)
            {
                TypeLeagueUser user = new TypeLeagueUser
                {
                    Email = userAddDTO.Email,
                    UserName = userAddDTO.UserName
                };
                IdentityResult result = await _userManager.CreateAsync(user, userAddDTO.Password);
                await _userManager.AddToRoleAsync(user,"user");
                if (result.Succeeded == false)
                {
                    return BadRequest(result);
                }
                return Ok();
            }
            return BadRequest(ModelState);
        }

        //Change password
        // POST: api/user/5/change_password
        // PUT requests should be idempotent, which this request is not, because it requires the old password which changes between requests.
        [HttpPost("{id}/change_password")]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> UpdatePassword(string id, UserUpdatePasswordDTO data)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                IdentityResult result = await _userManager.ChangePasswordAsync(user, data.Password, data.NewPassword);
                if (result.Succeeded == false)
                {
                    return BadRequest(result);
                }
                return Ok();
            }
            return BadRequest(ModelState);
        }


        // DELETE: api/user/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {

            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
                return NoContent();
            }

            return NotFound();

        }

        //Transforms the user resource into a format devoid of sensitive information,
        //only containing fields that should be returned to a Get request.
        private static UserGetDTO userToGetDTO(TypeLeagueUser user)
        {
            return new UserGetDTO
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Points = user.Points
            };
        }
    }
}
