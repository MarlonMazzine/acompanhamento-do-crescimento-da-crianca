using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.TCC.Context.Models
{
    public class Patient : IdentityUser
    {
        [Required(ErrorMessage = "Document is required.")]
        public string Document { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public string DoctorId { get; set; }

        private DateTime creationDate;
        public DateTime CreationDate
        {
            get { return DateTime.Now; }
            private set { creationDate = value; }
        }
    }
}
