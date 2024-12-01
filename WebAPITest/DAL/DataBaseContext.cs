using Microsoft.EntityFrameworkCore;
using WebAPITest.DAL.Entities;
using WebAPITest.DAL.Entities;

namespace WebAPITest.DAL
{
    public class DataBaseContext : DbContext
    {
        //Así me conecto a la BD por medio de este constructor
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
        //Este método que es propio de EF CORE me sirve para configurar unos índices de cada campo de una tabla en BD
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique(); //Aquí creo un índice del campo Name para la tabla Countries
            modelBuilder.Entity<State>().HasIndex("Name","CountryId").IsUnique(); //Haciendo índice compuesto
        }
        #region DbSets
        //Se crea por cada una de las entidades para identificar que son tablas
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        #endregion
    }
}
