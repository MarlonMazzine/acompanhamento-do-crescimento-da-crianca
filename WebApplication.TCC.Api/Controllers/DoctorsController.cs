using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication.TCC.Context.Datas;
using WebApplication.TCC.Context.Models;

namespace WebApplication.TCC.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/v1.0/[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly IRepository<Doctor> Repository;

        public DoctorsController(IRepository<Doctor> repository)
        {
            Repository = repository;
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            var doctors = Repository.FindAll;
            IList<Doctor> allDoctors = new List<Doctor>();

            foreach (var doctor in doctors)
            {
                allDoctors.Add(new Doctor
                {
                    Id = doctor.Id,
                    UserName = doctor.UserName,
                    Document = doctor.Document,
                    Email = doctor.Email,
                    Patients = doctor.Patients,
                    ConcurrencyStamp = null
                });
            }

            return Ok(allDoctors);
        }
    }
}
