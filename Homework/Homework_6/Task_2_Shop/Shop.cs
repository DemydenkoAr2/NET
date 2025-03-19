namespace Task_2_Shop;

public class Shop : IDisposable
{
    private string CompanyName { get; set; }
    private string Location { get; set; }
    private string Type { get; set; }
    private string[] Phones { get; set; }

    public Shop(string name, string location, string type, string[] phones)
    {
        CompanyName = name;
        Location = location;
        Type = type;
        Phones = phones;
        Console.WriteLine($"Shop \"{CompanyName}\" created.");
    }
    
    ~Shop()
    {
        Console.WriteLine($"Shop \"{CompanyName}\" destroyed.");
    }
    
    public void Dispose()
    {
        Console.WriteLine($"Shop \"{CompanyName}\" disposed via Dispose.");
        GC.SuppressFinalize(this); // Prevent the destructor from being called
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {CompanyName}");
        Console.WriteLine($"Address: {Location}");
        Console.WriteLine($"Type: {Type}");
    }
}