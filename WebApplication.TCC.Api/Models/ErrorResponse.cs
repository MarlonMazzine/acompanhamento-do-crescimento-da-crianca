using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Linq;

namespace WebApplication.TCC.Api.Models
{
    public class ErrorResponse
    {
        public int Code { get; set; }
        public string Mensage { get; set; }
        public ErrorResponse InnerError { get; set; }
        public string[] Details { get; set; }

        public static ErrorResponse From(Exception e)
        {
            if (e == null)
            {
                return null;
            }

            return new ErrorResponse
            {
                Code = e.HResult,
                Mensage = e.Message,
                InnerError = ErrorResponse.From(e.InnerException)
            };
        }

        public static object FromModelState(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(m => m.Errors);

            return new ErrorResponse
            {
                Code = 100,
                Mensage = "Houve erro(s) no envio da requisção",
                Details = erros.Select(e => e.ErrorMessage).ToArray()
            };
        }
    }
}
