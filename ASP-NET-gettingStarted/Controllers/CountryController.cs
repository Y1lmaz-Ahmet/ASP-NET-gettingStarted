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

        //GET: api/Country
        [HttpGet]
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

        
    }
}
