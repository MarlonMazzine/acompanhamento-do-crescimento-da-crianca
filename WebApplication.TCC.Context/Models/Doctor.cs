using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.TCC.Context.Models
{
    public class Doctor : IdentityUser
    {
        [Key]
        public long DoctorId { get; set; }
        public string Document { get; set; }
        public IList<DoctorPatient> Patients { get; set; }

        public Doctor()
        {
            Patients = new List<DoctorPatient>();
        }
    }
}
