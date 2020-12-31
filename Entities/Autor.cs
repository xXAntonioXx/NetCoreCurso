using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using NetCoreCurso.Entities;

namespace NetCoreCurso.Entities
{
    public class Autor{
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public List<Libro> Libros { get; set; }
    }
}