using System.ComponentModel.DataAnnotations;

namespace WebAPITest.DAL.Entities
{
    public class State : AuditBase
    {
        [Display(Name = "Estado/Departamento")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }

        //Así es como relaciono 2 tablas con EF Core:
        [Display(Name = "País")]
        public Country? Country { get; set; }
        //FK
        [Display(Name = "Id País")]
        public Guid CountryId { get; set; }
    }
}
