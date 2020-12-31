using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreCurso.Entities;

namespace NetCoreCurso.Contexts
{
    public class ApplicationDbContext : DbContext{

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<Autor> Autores { get; set;}
        public DbSet<Libro> Libro { get; set;}
    }
}