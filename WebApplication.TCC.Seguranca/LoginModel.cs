using System.ComponentModel.DataAnnotations;

namespace Tcc.Atuhentication
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "User")]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
