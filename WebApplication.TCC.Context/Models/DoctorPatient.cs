namespace WebApplication.TCC.Context.Models
{
    public class DoctorPatient
    {
        public long Id { get; set; }
        public Doctor Doctor { get; set; }
        public long PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
