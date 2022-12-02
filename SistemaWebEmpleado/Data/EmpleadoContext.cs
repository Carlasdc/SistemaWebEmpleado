using Microsoft.EntityFrameworkCore;
using SistemaWebEmpleado.Models;

namespace SistemaWebEmpleado.Data
{
    public class EmpleadoContext:DbContext
    {
        public EmpleadoContext(DbContextOptions<EmpleadoContext> options) :base(options) { }
        public DbSet<Empleado> Empleados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>().HasData(
               new Empleado
               {
                   Id = 1,
                   Nombre = "Tara",
                   Apellido = "Brewer",
                   DNI = "35986895",
                   Legajo = "AA12345",
                   Titulo = "Gerente"
               },
               new Empleado
               {
                   Id = 2,
                   Nombre = "Andrew",
                   Apellido = "Tippett",
                   DNI = "31207589",
                   Legajo = "AA23654",
                   Titulo = "Manager"

               });
        }

    }
}
