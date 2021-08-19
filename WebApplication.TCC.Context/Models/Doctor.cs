using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.TCC.Context.Models
{
    public class Doctor : IdentityUser
    {
        [Required(ErrorMessage = "Document is required.")]
        public string Document { get; set; }
    }
}
