
public class CovidData
{
    public long updated { get; set; }
    public string country { get; set; }
    public CountryInfo countryInfo { get; set; }
    public int cases { get; set; }
    public int todayCases { get; set; }
    public int deaths { get; set; }
    public int todayDeaths { get; set; }
    public int recovered { get; set; }
    public int todayRecovered { get; set; }
    public int active { get; set; }
    public int critical { get; set; }
    public int casesPerOneMillion { get; set; }
    public int deathsPerOneMillion { get; set; }
    public int tests { get; set; }
    public int testsPerOneMillion { get; set; }
    public int population { get; set; }
    public string continent { get; set; }
    public int oneCasePerPeople { get; set; }
    public int oneDeathPerPeople { get; set; }
    public int oneTestPerPeople { get; set; }
    public double activePerOneMillion { get; set; }
    public double recoveredPerOneMillion { get; set; }
    public double criticalPerOneMillion { get; set; }
}

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class CountryInfo
{
    public int _id { get; set; }
    public string iso2 { get; set; }
    public string iso3 { get; set; }
    public double lat { get; set; }
    public double @long { get; set; }
    public string flag { get; set; }
}
