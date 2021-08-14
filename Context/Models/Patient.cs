using System;

namespace WebApplication.TCC.Context.Models
{
    public class Patient : Person
    {
        public DateTime BirthDate { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public DoctorPatient Doctor { get; set; }

        private DateTime creationDate;
        public DateTime CreationDate
        {
            get { return creationDate; }
            private set { creationDate = DateTime.Now; }
        }

        public Patient()
        {
            Doctor = new DoctorPatient();
        }
    }
}
