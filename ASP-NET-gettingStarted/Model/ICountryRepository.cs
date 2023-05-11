namespace ASP_NET_gettingStarted.Model
{
    public interface ICountryRepository
    {
        //De interface ICountryRepository definieert de bewerkingen die nodig zijn om een collectie objecten te manipuleren via de CountryRepository klasse.
        //Dit is gedaan om de klasse los te koppelen van andere onderdelen van de code.

        void AddCountry(Country country);
        Country GetCountry(int id);
        IEnumerable<Country> GetAll(string continent);
        void RemoveCountry(Country country);
        void UpdateCountry(Country country);
        bool ExistsCountry(int id);
        IEnumerable<Country> GetAll();
    }
}
