using System;
using System.Text.RegularExpressions;

namespace WebApplication.TCC.Api.Validators
{
    public class CnsValidator
    {
        public bool IsCnsValid(string cnsNumber)
        {
            const byte defaultCnsSize = 15;
            char[] cns = GetAllDigits(cnsNumber).ToCharArray();

            if (!this.StartsWith(new string(cns), "1", "2", "7", "8", "9") || cns.Length != defaultCnsSize)
            {
                return false;
            }

            int soma = 0;

            for (int i = 0; i < cns.Length; i++)
            {
                soma += int.Parse(cns[i].ToString()) * (defaultCnsSize - i);
            }

            return soma % 11 == 0;
        }

        private bool StartsWith(string text, params string[] values)
        {
            foreach (string value in values)
            {
                if (text.StartsWith(value))
                {
                    return true;
                }
            }

            return false;
        }

        private string GetAllDigits(string cnsNumber)
        {
            return Regex.Replace(cnsNumber, "\\D", "");
        }
    }
}
