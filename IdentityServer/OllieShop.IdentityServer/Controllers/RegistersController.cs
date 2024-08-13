using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OllieShop.IdentityServer.Dtos;
using OllieShop.IdentityServer.Models;
using System.Threading.Tasks;

namespace OllieShop.IdentityServer.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RegistersController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegisterDto userRegisterDto)
        {
            var user = new ApplicationUser
            {
                UserName = userRegisterDto.Username,
                Email = userRegisterDto.Email,
                Name = userRegisterDto.Name,
                Surname = userRegisterDto.Surname,
            };

            var result = await _userManager.CreateAsync(user, userRegisterDto.Password);

            if (result.Succeeded)
            {
                // "User" rolünü kontrol et ve oluştur
                if (!await _roleManager.RoleExistsAsync("User"))
                {
                    var roleResult = await _roleManager.CreateAsync(new ApplicationRole { Name = "User" });
                    if (!roleResult.Succeeded)
                    {
                        return StatusCode(500, "Role creation failed.");
                    }
                }

                // Kullanıcıyı "User" rolüne ekle
                var addToRoleResult = await _userManager.AddToRoleAsync(user, "User");
                if (!addToRoleResult.Succeeded)
                {
                    return StatusCode(500, "Adding user to role failed.");
                }

                return Ok("User added successfully.");
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }
    }
}
