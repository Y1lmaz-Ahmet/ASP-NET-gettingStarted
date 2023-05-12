using ASP_NET_gettingStarted.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_gettingStarted.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        //Om de repository te kunnen gebruiken in de controller voegen we een variabele van het
        //type ICountryRepository toe aan de klasse CountryController
        //en initialiseren deze in de constructor.
        private ICountryRepository _countryRepository;

        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        //[HttpGet("start")]
        [HttpGet("[action]")]
        public IActionResult Start()
        {
            return Ok(_countryRepository.GetAll());
        }
        [HttpGet("[action]/{id:int=3}")]
        public IActionResult GetCountryByCountryId(int id)
        {
            return Ok( _countryRepository.GetCountry(id));
        }

        //GET: api/Country
        [HttpGet("[action]")]
        [HttpHead]
        //[FromQuery] string continent = null
        //code hierboven zorgt ervoor dat als de continent niet ingegeven wordt
        //dat de else statement werkt en alle continenten gegeven wordt.
        public IEnumerable<Country> GetAllCountries([FromQuery] string continent = null)
        {
            if (!string.IsNullOrWhiteSpace(continent))
                return _countryRepository.GetAll(continent);
            else
                return _countryRepository.GetAll();
        }
        //GET: api/country/{id}
        [HttpGet("{id}")]
        [HttpHead("{id}")]
        public ActionResult<Country> GetCountryById(int id)
        {
            try
            {
                return Ok(_countryRepository.GetCountry(id));
            }
            catch(CountryException ex)
            {
                
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddCountry([FromBody] Country country)
        {
            try
            {
                _countryRepository.AddCountry(country);
               return CreatedAtAction(nameof(GetAllCountries),new {id = country.Id}, country);
            }
            catch (CountryException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCountry(int id)
        {
            if (!_countryRepository.ExistsCountry(id))
            {
                return Ok("[DeleteCountry]: country doesn't exist");
            }
            _countryRepository.RemoveCountry(_countryRepository.GetCountry(id));
            return Ok("[DeleteCountry]: country has been deleted.");
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Country country)
        {
            if (country == null)
            {
                return BadRequest("The country object is null.");
            }

            if (country.Id != id)
            {
                return BadRequest("The specified country ID does not match the provided ID.");
            }

            var existingCountry = _countryRepository.GetCountry(id);

            if (existingCountry == null)
            {
                _countryRepository.AddCountry(country);
                return CreatedAtAction(nameof(GetAllCountries), new { id = country.Id }, country);
            }

            _countryRepository.UpdateCountry(country);
            return new NoContentResult();
        }


    }
}
