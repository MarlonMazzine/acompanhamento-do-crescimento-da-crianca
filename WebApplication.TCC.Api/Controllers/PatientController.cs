using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
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
                    return Ok(patients);
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
                return BadRequest("Patient's document is invalid.");
            } else if (!new BirthdateValidator().IsBirthdateValid(model.Birthdate))
            {
                return BadRequest("Patient's birthdate is invalid.");
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

        [HttpGet("{doctorId}/{urlName}/{value}")]
        public IActionResult GetPatientsOfADoctorByValue(string doctorId, string urlName, string value)
        {
            if (IsDoctorFound(doctorId))
            {
                IList<Patient> patients = Repository.FindAll.ToList();
                IEnumerable<Patient> patientsOfDoctor = patients.Where(p => p.DoctorId.Equals(doctorId));

                switch (urlName)
                {
                    case "sus":
                        return Ok(patientsOfDoctor.Where(p => p.Document.Equals(value)));
                    case "name":
                        return Ok(patientsOfDoctor.Where(p => p.UserName.Equals(value)));
                    case "birthdate":
                        return Ok(patientsOfDoctor.Where(p => p.Birthdate.Equals(value)));
                    default:
                        break;
                }
            }

            return BadRequest(new { warningMessage = "Doctor not found." });
        }

        //private IEnumerable<HeightWeight> GetPatienHeightsAndWeights(string id)
        //{
        //    using (var context = new PatientContext())
        //    {
        //        return context.HeightWeight.
        //    }
        //}

        private bool IsDoctorFound(string doctorId)
        {
            using (var db = new PatientContext())
            {
                return db.Doctors.Find(doctorId) != null;
            }
        }
    }
}
