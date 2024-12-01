using System.ComponentModel.DataAnnotations;

namespace WebAPITest.DAL.Entities
{
    public class AuditBase
    {
        [Key] //PK
        [Required] //Significa que este campo es obligatorio
        public virtual Guid ID { get; set; } //Esta será el PK de todas las tablas
        public virtual DateTime? CreatedDate { get; set; } //Para guardar todo registro nuevo con su fecha
        public virtual DateTime? ModifiedDate { get; set; } //Para guardar todo registro que se modificó con su fecha
    }
}
