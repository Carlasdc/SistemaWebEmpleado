using SistemaWebEmpleado.Validations;
using System.ComponentModel.DataAnnotations;

namespace SistemaWebEmpleado.Models
{
    public class Empleado
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string  DNI { get; set; }
        [Required]
        [ValidationLegajo]
        public string Legajo { get; set; }
        [Required]
        public string Titulo { get; set; }
    }
}
