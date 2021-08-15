namespace WebApplication.TCC.Context.Models
{
    public class DoctorPatient
    {
        public string Id { get; set; }
        public Doctor Doctor { get; set; }
        public string PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
