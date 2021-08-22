using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
            if (ModelState.IsValid && this.IsPatientExist(model.PatientId))
            {
                Repository.Insert(model);
                Uri uri = new Uri($"{Request.Scheme}://{Request.Host.Value}/weightheight/{model.Id}");

                return Created(uri, "Created");
            }

            return BadRequest();
        }

        [HttpGet("{patientId}")]
        public IActionResult GetByPatientId(string patientId)
        {
            if (!this.IsPatientExist(patientId))
            {
                return BadRequest(new { errorMessage = "Patient not found." });
            }

            IList<HeightWeight> heightWeight = Repository.FindAll.ToList();
            IEnumerable<HeightWeight> heightWeightOfPatient = heightWeight.Where(hW => hW.PatientId.Equals(patientId));

            if (heightWeightOfPatient.Count() == 0)
            {
                return NoContent();
            }

            return Ok(heightWeightOfPatient);
        }

        private bool IsPatientExist(string patientId)
        {
            using (var context = new PatientContext())
            {
                return context.Patients.Find(patientId) != null;
            }
        }
    }
}
