using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Tcc.Atuhentication;
using WebApplication.TCC.AuthProvider.Models;
using WebApplication.TCC.Context.Models;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace WebApplication.TCC.AuthProvider.Controller
{
    [ApiController]
    [Route("api/v1.0/[controller]")]
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
                SignInResult result = await _signInManager.PasswordSignInAsync(model.Login, model.Password, true, true);

                if (result.Succeeded)
                {
                    JwtSecurityToken token = this.MountToken(model);

                    return Ok($"Bearer {new JwtSecurityTokenHandler().WriteToken(token)}");
                }

                return Unauthorized(); //401
            }

            return BadRequest(ErrorResponse.FromModelState(ModelState)); //400
        }

        private JwtSecurityToken MountToken(LoginModel model)
        {
            Claim[] claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, model.Login),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("tcc-webapi-authentication-valid"));
            SigningCredentials credencials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            return new JwtSecurityToken(
                issuer: "Tcc.WebApp",
                audience: "Insomnia",
                claims: claims,
                signingCredentials: credencials,
                expires: DateTime.Now.AddDays(1)
            );
        }
    }
}
