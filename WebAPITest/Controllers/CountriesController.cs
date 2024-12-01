using Microsoft.AspNetCore.Mvc;
using WebAPITest.DAL.Entities;
using WebAPITest.Domain.Interfaces;

namespace WebAPITest.Controllers
{
    [Route("api/[controller]")] //Este es el nombre inicial de mi RUTA, URL, o PATH
    [ApiController]
    public class CountriesController : Controller
    {
        private readonly ICountryService _countryService;
        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Country>>> GetContriesAsync()
        {
            var countries = await _countryService.GetContriesAsync();
            if (countries == null || !countries.Any()) return NotFound(); //NotFound = Status Code
            return Ok(countries); //Ok = Status Code 200
        }
        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")] //URL: api/countries/Get
        public async Task<ActionResult<Country>> GetCountryByIdAsync(Guid id)
        {
            var country = await _countryService.GetCountryByIdAsync(id);
            if (country == null) return NotFound();
            return Ok(country);
        }
        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<Country>> CreateCountryAsync(Country country)
        {
            try
            {
                var newCountry = await _countryService.CreateCountryAsync(country);
                if (newCountry == null) return NotFound();
                return Ok(newCountry);
            }
            catch (Exception ex)
            {

                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", country.Name));
                return Conflict(ex.Message);

            }
        }
        [HttpPost, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<Country>> EditCountryAsync(Country country)
        {
            try
            {
                var editedCountry = await _countryService.EditCountryAsync(country);
                if (editedCountry == null) return NotFound();
                return Ok(editedCountry);
            }
            catch (Exception ex)
            {

                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", country.Name));
                return Conflict(ex.Message);

            }

        }
        [HttpPost, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<Country>> DeleteCountryAsync(Guid id)
        {
            if (id == null) return BadRequest();
            var deletedCountry = await _countryService.DeleteCountryAsync(id);
            if (deletedCountry == null) return NotFound();
            return Ok(deletedCountry);

        }

    }
}
