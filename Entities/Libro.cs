using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using NetCoreCurso.Entities;

namespace NetCoreCurso.Entities
{
    public class Libro{
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }
        [Required]
        public int AutorId { get; set; }
        public Autor Autor { get; set; }
    }
}