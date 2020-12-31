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
    public class AutorController : ControllerBase{

        private readonly ApplicationDbContext context;

        public AutorController(ApplicationDbContext context){
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Autor>> Get(){
            return this.context.Autores.ToList();
        }

        [HttpGet("{id}", Name = "ObtenerAutor")]
        public ActionResult<Autor> Get(int id){
            var autor = this.context.Autores.FirstOrDefault(x => x.Id == id);

            if(autor == null){
                return NotFound();
            }

            return autor;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Autor autor){
            this.context.Autores.Add(autor);
            this.context.SaveChanges();
            return new CreatedAtRouteResult("ObtenerAutor", new { Id = autor.Id }, autor);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Autor value){

            if(id != value.Id){
                return BadRequest();
            }

            this.context.Entry(value).State = EntityState.Modified;
            this.context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Autor> Delete(int id){
            var autor = this.context.Autores.FirstOrDefault(x => x.Id == id);

            if(autor == null){
                return NotFound();
            }

            this.context.Autores.Remove(autor);
            this.context.SaveChanges();
            return autor;
        }
    }
}