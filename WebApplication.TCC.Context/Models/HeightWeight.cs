using System;

namespace WebApplication.TCC.Context.Models
{
    public class HeightWeight
    {
        public string Id { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public string PatientId { get; set; }

        private DateTime creationDate;
        public DateTime CreationDate
        {
            get { return creationDate; }
            set { creationDate = DateTime.Now; }
        }
    }
}
