using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TypeLeague.Models.UserModels;

namespace TypeLeague.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserManager<TypeLeagueUser> _userManager;
        private readonly IConfiguration _configuration; 

        public LoginController(UserManager<TypeLeagueUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        // POST: api/login
        
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<String>> PostUser(LoginPostDTO loginPostDTO)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginPostDTO.Email);
                if (user == null)
                {
                    return NotFound();
                }
                bool result = await _userManager.CheckPasswordAsync(user, loginPostDTO.Password);
                if (result == false)
                {
                    return BadRequest("Incorrect email or password");
                }
                var token = CreateJWT(user.Id);
                string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(new { token = tokenString });
            }
            return BadRequest(ModelState);
        }

        private JwtSecurityToken CreateJWT(string userId)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecret"]));
            var _credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var _claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: _claims,
                expires: DateTime.UtcNow.AddMinutes(120),
                signingCredentials: _credentials
                );
            return token;
        }
    }
}
