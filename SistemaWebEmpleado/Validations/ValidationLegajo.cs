using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SistemaWebEmpleado.Validations
{
    public class ValidationLegajo : ValidationAttribute
    {
        public ValidationLegajo()
        {
            ErrorMessage = "El legajo debe contener AA y 5 numeros.";
        }

        public override bool IsValid(object value)
        {
            string legajo = Convert.ToString(value);
            string pattern = @"AA\d{5}";
            return Regex.IsMatch(legajo, pattern);
        }
    }
}