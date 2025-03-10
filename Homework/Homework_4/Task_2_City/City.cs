namespace Task_2_City;

public class City
{
    private string CityName { get; set; }
    private int CityPopulation { get; set; }

    public City(string cityName, int cityPopulation)
    {
        CityName = cityName;
        CityPopulation = cityPopulation;
    }

    public static City operator +(City city, int peoples)
    {
        city.CityPopulation += peoples;
        return city;
    }

    public static City operator -(City city, int peoples)
    { 
        city.CityPopulation -= peoples;
        return city;
    }

    public static bool operator ==(City city1, City city2)
    {
        return city1.CityPopulation == city2.CityPopulation;
    }

    public static bool operator !=(City city1, City city2)
    {
        return city1.CityPopulation == city2.CityPopulation;
        
    }

    public static bool operator <(City city1, City city2)
    {
        return city1.CityPopulation < city2.CityPopulation;
    }

    public static bool operator >(City city1, City city2)
    {
        return city1.CityPopulation > city2.CityPopulation;
    }

    public void GetInfo()
    {
        Console.WriteLine($"City Name: {CityName}, Population: {CityPopulation}");
    }
}