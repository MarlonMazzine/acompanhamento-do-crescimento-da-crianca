using System;

namespace WebApplication.TCC.Context.Models
{
    public class HeighCalculations
    {
        public long Id { get; set; }
        public Patient PatientId { get; set; }
        public double Result { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
