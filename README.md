## Projectnaam

Beschrijving van het project.

### Hoe te gebruiken

- Instructies om het project te downloaden en te installeren.
- Instructies om het project te gebruiken.

### API-methoden

#### `GetAllCountries([FromQuery] string continent = null)`

Deze methode haalt een lijst op van alle landen die in de database zijn opgeslagen. De parameter `continent` is optioneel en kan worden gebruikt om alleen landen van een specifiek continent op te halen.

#### `GetCountryById(int id)`

Deze methode haalt een enkel land op op basis van het `id`-nummer dat als parameter wordt meegegeven. Als het opgegeven `id`-nummer niet overeenkomt met een land in de database, wordt er een `NotFound`-statuscode geretourneerd.

#### `AddCountry([FromBody] Country country)`

Deze methode voegt een nieuw land toe aan de database. Als er een fout optreedt tijdens het toevoegen van het land, wordt er een `BadRequest`-statuscode geretourneerd met een bijbehorend foutbericht.

#### `DeleteCountry(int id)`

Deze methode verwijdert een land uit de database op basis van het `id`-nummer dat als parameter wordt meegegeven. Als het opgegeven `id`-nummer niet overeenkomt met een land in de database, wordt er een `Ok`-statuscode geretourneerd met een bijbehorend foutbericht.

#### `Put(int id, [FromBody] Country country)`

Deze methode werkt het land bij op basis van het `id`-nummer dat als parameter wordt meegegeven en de gegevens die zijn opgegeven in de `Country`-object. Als het opgegeven `id`-nummer niet overeenkomt met een land in de database, wordt er een `BadRequest`-statuscode geretourneerd met een bijbehorend foutbericht. Als er een fout optreedt tijdens het bijwerken van het land, wordt er een `NoContent`-statuscode geretourneerd.