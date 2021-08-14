using Microsoft.AspNetCore.Identity;

namespace WebApplication.TCC.Context.Models
{
    public class Person// : IdentityUser<long>
    {
        //public long Id { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }
    }
}
