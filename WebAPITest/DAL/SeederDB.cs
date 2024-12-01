
using WebAPITest.DAL.Entities;

namespace WebAPITest.DAL
{
    public class SeederDB
    {
        private readonly DataBaseContext _context;
        public SeederDB(DataBaseContext context)
        {
            _context = context;
        }
        //Crearemos un método llamado SeederAsync() que es una especie de Main(), tendrá la responsabilidad de prepoblar mis diferentes tablas de la BD
        public async Task SeederAsync()
        {
            //Primero: Agregaré un método propio de EF que hace las veces del comando 'update-database'
            //En otras palabras: Un método que me creará la BD inmediatamente ponga en ejecución mi API
            await _context.Database.EnsureCreatedAsync();
            //A partir de aquí vamos a ir creando métodos que me sirvan para prepoblar mi BD
            await PopulateCountriesAsync(); //Poblar los datos
            await _context.SaveChangesAsync();//Guardar en la BD
        }
        #region Private Methos
        private async Task PopulateCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Country
                {
                    CreatedDate = DateTime.Now,
                    Name = "Colombia",
                    States = new List<State>()
                    {
                        new State
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Antioquia"
                        },
                        new State
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Cundinamarca"
                        }
                    }
                });
                _context.Countries.Add(new Country
                {
                    CreatedDate = DateTime.Now,
                    Name = "Argentina",
                    States = new List<State>()
                    {
                        new State
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Buenos Aires"
                        }
                    }
                });
            }
        }
    }
    #endregion
}
