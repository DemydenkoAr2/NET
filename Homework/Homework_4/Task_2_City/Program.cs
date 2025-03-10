namespace Task_2_City;

class Program
{
    static void Main(string[] args)
    {
        City OdessaCity = new City("Odessa", 992874);
        City KharkivCity = new City("Kharkiv", 1421125 );
        
        OdessaCity += 2000;
        KharkivCity -= 30059;
        
        OdessaCity.GetInfo(); // City Name: Odessa, Population: 994874
        KharkivCity.GetInfo(); // City Name: Kharkiv, Population: 1391066

        Console.WriteLine(OdessaCity == KharkivCity); // False
        Console.WriteLine(OdessaCity != KharkivCity); // False
        Console.WriteLine(OdessaCity > KharkivCity); // False
        Console.WriteLine(OdessaCity < KharkivCity); // True
    }
}