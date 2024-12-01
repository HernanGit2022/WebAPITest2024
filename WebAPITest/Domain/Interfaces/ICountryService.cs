using WebAPITest.DAL.Entities;

namespace WebAPITest.Domain.Interfaces
{
    public interface ICountryService
    {
        //Métodos CRUD
        Task<IEnumerable<Country>> GetContriesAsync(); //Obtiene un IEnumerable de todos los países de la BD
        Task<Country> GetCountryByIdAsync(Guid Id); //Obtener un país por el ID
        Task<Country> CreateCountryAsync(Country country); //Crear un país en la IEnumerable, es decir en la BD
        Task<Country> EditCountryAsync(Country country); //Editar o actualizar un País en la IEnumerable, es decir en la BD
        Task<Country> DeleteCountryAsync(Guid Id); //Eliminar un país con el ID
    }
}
