using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication.TCC.Context.Models;
using WebApplication.TCC.Seguranca;

namespace WebApplication.TCC.AuthProvider.Controller
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SignupController : ControllerBase
    {
        private readonly UserManager<Doctor> _userManager;

        public SignupController(UserManager<Doctor> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register(SignupModel model)
        {
            if (ModelState.IsValid)
            {
                Doctor user = new Doctor
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Document = model.Document
                };

                IdentityResult result = await _userManager.CreateAsync(user, model.PasswordHash);
                
                if (result.Succeeded)
                {
                    string uri = Url.Action("Login", new { model = model });
                    
                    return Created(uri, model);
                }
            }

            return BadRequest();
        }
    }
}
