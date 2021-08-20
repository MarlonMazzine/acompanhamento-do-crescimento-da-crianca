using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApplication.TCC.Context.Datas;
using WebApplication.TCC.Context.Models;

namespace WebApplication.TCC.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/v1.0/[controller]")]
    public class WeightHeightController : ControllerBase
    {
        private readonly IRepository<HeightWeight> Repository;

        public WeightHeightController(IRepository<HeightWeight> repository)
        {
            Repository = repository;
        }

        [HttpPost]
        public IActionResult Register([FromBody] HeightWeight model)
        {
            if (ModelState.IsValid)
            {
                using (var context = new PatientContext())
                {
                    Patient patient = context.Patients.Find(model.PatientId);

                    if (patient == null)
                    {
                        return BadRequest();
                    }
                }

                Repository.Insert(model);
                Uri uri = new Uri($"{Request.Scheme}://{Request.Host.Value}/weightheight/{model.Id}");

                return Created(uri, "Created");
            }

            return BadRequest();
        }
    }
}
