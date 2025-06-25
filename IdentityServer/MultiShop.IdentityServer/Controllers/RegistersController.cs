using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.DTOs;
using MultiShop.IdentityServer.Models;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace MultiShop.IdentityServer.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]")]
    public class RegistersController : ControllerBase
    {
        #region Fields

        private readonly UserManager<ApplicationUser> _userManager;

        #endregion

        #region Ctor

        public RegistersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        #endregion

        #region Methods

        [HttpPost]
        public async Task<IActionResult> UserRegister([FromBody] UserRegisterDto userRegisterDto)
        {
            var applicationUser = new ApplicationUser
            {
                UserName = userRegisterDto.UserName,
                Email = userRegisterDto.Email,
                Name = userRegisterDto.Name,
                Surname = userRegisterDto.Surname,
            };

            var result = await _userManager.CreateAsync(applicationUser, userRegisterDto.Password);

            if (result.Succeeded)
            {
                return Ok("Kullanıcı başarıyla eklendi");
            }

            return BadRequest("Bir hata oluştu, tekrar deneyiniz");
        }

        #endregion
    }
}
