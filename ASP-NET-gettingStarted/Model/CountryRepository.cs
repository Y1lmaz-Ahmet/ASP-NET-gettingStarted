namespace ASP_NET_gettingStarted.Model
{
    public class CountryRepository : ICountryRepository
    {
        private Dictionary<int,Country> data = new Dictionary<int,Country>();
        public CountryRepository() 
        {
            data.Add(1, new Country(1, "Nederland", "Amsterdam", "Europa"));
            data.Add(2, new Country(2, "Verenigde Staten", "Washington D.C.", "Noord-Amerika"));
            data.Add(3, new Country(3, "Australië", "Canberra", "Oceanië"));
            data.Add(4, new Country(4, "Brazilië", "Brasília", "Zuid-Amerika"));
            data.Add(5, new Country(5, "Japan", "Tokio", "Azië"));
            data.Add(6, new Country(6, "Zuid-Afrika", "Pretoria", "Afrika"));
            data.Add(7, new Country(7, "Spanje", "Madrid", "Europa"));
            data.Add(8, new Country(8, "Duitsland", "Berlijn", "Europa"));
            data.Add(9, new Country(9, "Italië", "Rome", "Europa"));
        }
        public void AddCountry(Country country)
        {
            if (!data.ContainsKey(country.Id))
            {
                data.Add(country.Id, country);
            }
            else
            {
                throw new CountryException("[AddCountry]: Country already exists");
            }
        }

        public IEnumerable<Country> GetAll()
        {
            return data.Values;
        }

        public Country GetCountry(int id)
        {
            if (data.TryGetValue(id, out Country value))
                return value;
            else
                throw new CountryException("[GetCountry]: Country doesn't exist");
            
        }

        public void RemoveCountry(Country country)
        {
            if (data.ContainsKey(country.Id))
            {
                data.Remove(country.Id);
            }
            else
            {
                throw new CountryException("[RemoveCountry]: Country doesn't exist");
            }
        }

        public void UpdateCountry(Country country)
        {
            if (data.ContainsKey(country.Id))
            {
                data[country.Id] = country;
            }else
            {
                throw new CountryException("[UpdateCountry]: Country doesn't exist");
            }
        }
    }
}
