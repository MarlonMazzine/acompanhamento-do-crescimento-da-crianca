using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.TCC.Context.Models
{
    public class Patient : IdentityUser
    {
        [Required(ErrorMessage = "Document is required.")]
        public string Document { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }

        public DateTime BirthDate { get; set; }
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
