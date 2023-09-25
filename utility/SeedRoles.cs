using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TypeLeague.Models;
using TypeLeague.Models.UserModels;

namespace TypeLeague.utility
{
    /// <summary>
    /// A static class to seed roles in the database on startup.
    /// </summary>
    public static class SeedRoles
    {
        public async static void Initialize(RoleManager<IdentityRole> _roleManager)
        {
            string[] roles = new string[] { "admin", "user" };
            foreach (string role in roles)
            {
                if (!(await _roleManager.RoleExistsAsync(role)))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
