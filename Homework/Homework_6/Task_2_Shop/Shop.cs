namespace Task_2_Shop;

public class Shop : IDisposable
{
    private bool _disposed = false;
    
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
    }
    
    ~Shop()
    {
        Console.WriteLine($"Shop \"{CompanyName}\" destroyed.");
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                Console.WriteLine($"Shop \"{CompanyName}\" disposed via Dispose.");
            }
            
            _disposed = true;
        }
    }
    
    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {CompanyName}, Location: {Location},  Type: {Type}");
    }

    public void UpdateInfo(string newLocation, string newType)
    {
        Location = newLocation;
        Type = newType;
    }
}