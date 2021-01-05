using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using NetCoreCurso.Entities;
using NetCoreCurso.Helpers;

namespace NetCoreCurso.Entities
{
    public class Autor : IValidatableObject {
        public int Id { get; set; }

        [Required]
        //[PrimeraLetraMayuscula]
        [StringLength(50)]
        public string Nombre { get; set; }
        public List<Libro> Libros { get; set; }

        [Range(18, 120)]
        public int Edad { get; set; }

        [CreditCard]
        public string CreditCard { get; set; }

        [Url]
        public string Url { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext){
            
            if (!string.IsNullOrEmpty(Nombre)){

                var primeraLetra = Nombre[0].ToString();

                if (primeraLetra != primeraLetra.ToUpper()){

                    yield return new ValidationResult("La primera letra debe ser Mayúscula(validación desde el modelo)", new string[] { nameof(Nombre) });

                }
            }
        }
    }
}