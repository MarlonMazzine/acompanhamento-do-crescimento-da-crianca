using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Tcc.Atuhentication;
using WebApplication.TCC.Api.Models;
using WebApplication.TCC.Context.Models;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace WebApplication.TCC.Api.Controller
{
    [ApiController]
    [Route("api/v1.0/[controller]")]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<Doctor> _signInManager;

        public LoginController(SignInManager<Doctor> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> GetToken(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                SignInResult result = await _signInManager.PasswordSignInAsync(model.Login, model.Password, false, false);

                if (result.Succeeded)
                {
                    return Ok(DoctorLoggedObject(model));
                }

                return Unauthorized(); //401
            }

            return BadRequest(ErrorResponse.FromModelState(ModelState)); //400
        }

        private object DoctorLoggedObject(LoginModel model)
        {
            string token = this.MountToken(model);
            Doctor user = _signInManager.UserManager.Users.ToList().Where(u => u.UserName == model.Login).First();

            return new
            {
                token = $"Bearer {token}",
                doctor = new
                {
                    id = user.Id,
                    userName = user.UserName,
                    document = user.Document,
                    email = user.Email,
                }
            };
        }

        private string MountToken(LoginModel model)
        {
            Claim[] claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, model.Login),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("tcc-webapi-authentication-valid"));
            SigningCredentials credencials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "Tcc.WebApp",
                audience: "Insomnia",
                claims: claims,
                signingCredentials: credencials,
                expires: DateTime.Now.AddDays(1)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
