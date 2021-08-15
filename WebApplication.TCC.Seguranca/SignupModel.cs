using System.ComponentModel.DataAnnotations;
using WebApplication.TCC.Context.Models;

namespace WebApplication.TCC.Seguranca
{
    public class SignupModel : Doctor
    {
        [DataType(DataType.Password)]
        [Display(Name = "Password confirmation")]
        [Compare("PasswordHash", ErrorMessage = "Senha e confirmação são diferentes.")]
        public string ConfirmPassword { get; set; }
    }
}
