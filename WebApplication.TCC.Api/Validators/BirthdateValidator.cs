using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.TCC.Api.Validators
{
    public class BirthdateValidator
    {
        public bool IsBirthdateValid(DateTime birthdate)
        {
            DateTime now = DateTime.Now;
            double monthsDifference = ((now.Year - birthdate.Year) * 12) + now.Month - birthdate.Month;

            return monthsDifference > 0 && monthsDifference <= 228;
        }
    }
}
