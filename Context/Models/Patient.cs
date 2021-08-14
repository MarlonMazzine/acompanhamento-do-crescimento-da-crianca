using System;

namespace WebApplication.TCC.Context.Models
{
    public class Patient : Person
    {
        public DateTime BirthDate { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public DoctorPatient Doctor { get; set; }
        public DateTime CreationDate { get; set; }

        public Patient()
        {
            Doctor = new DoctorPatient();
        }
    }
}
