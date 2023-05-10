namespace ASP_NET_gettingStarted.Model
{
    public class Country
    {
        #region Properties voor Country Class
        public int Id { get; set; }
        public string Name { get; set; }
        public string Capital { get; set; }
        public string Continent { get; set; }
        #endregion

        #region Constructor voor Country Class
        public Country(int id, string name, string capital,string continent)
        {
            Id = id;
            Name = name;
            Capital = capital;
            Continent = continent;
        }
        public Country(string name,string capital,string continent)
        {
            Name = name;
            Capital = capital;
            Continent = continent;
        }

        //leeg class zodat POST method in controller werkt, anders error : parameterless...
        public Country()
        {
        }
        #endregion
    }
}
