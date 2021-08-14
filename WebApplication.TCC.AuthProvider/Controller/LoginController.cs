using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Tcc.Atuhentication;
using WebApplication.TCC.Context.Models;

namespace WebApplication.TCC.AuthProvider.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<Doctor> _signInManager;

        public LoginController(SignInManager<Doctor> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Token(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Login, model.Password, true, true);
                if (result.Succeeded)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, model.Login),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    };

                    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("tcc-webapi-authentication-valid"));
                    var credencials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        issuer: "Tcc.WebApp",
                        audience: "Insomnia",
                        claims: claims,
                        signingCredentials: credencials,
                        expires: DateTime.Now.AddDays(1)
                    );

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                return Unauthorized(); //401
            }
            return BadRequest(); //400
        }
    }
}
