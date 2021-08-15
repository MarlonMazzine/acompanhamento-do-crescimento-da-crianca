using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApplication.TCC.AuthProvider.Models;
using WebApplication.TCC.Context.Models;
using WebApplication.TCC.Seguranca;

namespace WebApplication.TCC.AuthProvider.Controller
{
    [ApiController]
    [Route("api/v1.0/[controller]")]
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
                    Uri uri = new Uri($"{Request.Scheme}://{Request.Host.Value}/{user.Id}");

                    return Created(uri, new
                        {
                            doctorInformations = new
                            {
                                id = user.Id,
                                userName = user.UserName,
                                document = user.Document,
                                email = user.Email,
                                patients = user.Patients
                            }
                        }
                    );
                }

                foreach (var error in result.Errors)
                {
                    //return BadRequest(error.Description);
                    ModelState.AddModelError(error.Code, error.Description);
                }
            }

            return BadRequest(ErrorResponse.FromModelState(ModelState));
        }
    }
}
