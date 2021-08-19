using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication.TCC.Api.Validators;
using WebApplication.TCC.Context.Datas;
using WebApplication.TCC.Context.Models;

namespace WebApplication.TCC.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/v1.0/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IRepository<Patient> Repository;

        public PatientController(IRepository<Patient> repository)
        {
            Repository = repository;
        }

        [HttpGet("{doctorId}")]
        public IActionResult GetTotalPatientsByDoctorId(string doctorId)
        {
            if (IsDoctorFound(doctorId))
            {
                var patients = Repository.FindAll.ToList().Where(p => p.DoctorId.Equals(doctorId));

                if (patients.Any())
                {
                    return Ok(patients.Count());
                }

                return NoContent();
            }

            return BadRequest(new { warningMessage = "Doctor not found." });
        }

        [HttpGet("patients-by-doctor/{doctorId}")]
        public IActionResult GetPatientsByDoctorId(string doctorId)
        {
            if (IsDoctorFound(doctorId))
            {
                var patients = Repository.FindAll.ToList().Where(p => p.DoctorId.Equals(doctorId));

                if (patients.Any())
                {
                    return Ok(patients);
                }

                return NoContent();
            }

            return BadRequest(new { warningMessage = "Doctor not found." });
        }

        [HttpPost]
        public IActionResult CreatePatient([FromBody] Patient model)
        {
            if (!new CnsValidator().IsCnsValid(model.Document))
            {
                return BadRequest(new { errorMessage = "Patient's document is invalid." });
            }

            if (IsDoctorFound(model.DoctorId))
            {
                Repository.Insert(model);
                return Ok();
            }
            else
            {
                return BadRequest(new { warningMessage = "Doctor not found." });
            }
        }

        private bool IsDoctorFound(string doctorId)
        {
            using (var db = new PatientContext())
            {
                return db.Doctors.Find(doctorId) != null;
            }
        }
    }
}
