using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreCurso.Contexts;
using NetCoreCurso.Entities;
using Microsoft.EntityFrameworkCore;

namespace NetCoreCurso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase{

        private readonly ApplicationDbContext context;

        public LibrosController(ApplicationDbContext context){
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Libro>> Get(){
            return this.context.Libro.Include(x => x.Autor).ToList();
        }

        [HttpGet("Primer")]
        public ActionResult<Autor> GetPrimerAutor(){
            return this.context.Autores.FirstOrDefault();
        }

        [HttpGet("{id}", Name = "ObtenerLibro")]
        public ActionResult<Libro> Get(int id, string param2){

            var libro = this.context.Libro.Include(x => x.Autor).FirstOrDefault(x => x.Id == id);

            if(libro == null){

                return NotFound();

            }

            return libro;

        }

        [HttpPost]
        public ActionResult Post([FromBody] Libro libro){
            this.context.Libro.Add(libro);
            this.context.SaveChanges();
            return new CreatedAtRouteResult("ObtenerLibro", new { id = libro.Id }, libro);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Libro libro){
            
            if(id != libro.Id){
                return BadRequest();
            }

            this.context.Entry(libro).State = EntityState.Modified;
            this.context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Libro> Delete(int id){
            var libro = this.context.Libro.FirstOrDefault(x => x.Id == id);

            if(libro == null){
                return NotFound();
            }

            this.context.Libro.Remove(libro);
            this.context.SaveChanges();
            return libro;
        }
    }
}