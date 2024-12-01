using System.ComponentModel.DataAnnotations;

namespace WebAPITest.DAL.Entities
{
    public class State : AuditBase
    {
        [Display(Name = "Departamento")] //Para identificar el nombre más fácil
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")] //Longitud máximo
        [Required(ErrorMessage = "El campo {0} es obligatorio")] //Campo obligatorio
        public string Name { get; set; }
    }
}
