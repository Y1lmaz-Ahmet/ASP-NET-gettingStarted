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
    }
}
