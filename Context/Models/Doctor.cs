using System.Collections.Generic;

namespace WebApplication.TCC.Context.Models
{
    public class Doctor : Person
    {
        public string Password { get; set; }
        public IList<DoctorPatient> Patients { get; set; }

        public Doctor()
        {
            Patients = new List<DoctorPatient>();
        }
    }
}
