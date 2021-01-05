using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NetCoreCurso.Helpers
{
    public class PrimeraLetraMayusculaAttribute : ValidationAttribute{

        protected override ValidationResult IsValid(object value, ValidationContext validationContext){
            
            if (value == null || string.IsNullOrEmpty(value.ToString())) {
                
                return ValidationResult.Success;

            }

            var firstLetter = value.ToString()[0].ToString();

            if (firstLetter != firstLetter.ToUpper()){

                return new ValidationResult("La primera letra debe ser mayúscula");

            }

            return ValidationResult.Success;

        }
    }
}