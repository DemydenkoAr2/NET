namespace HW_Money;

public class Product : Money
{
    private string ProductName { get; set; }

    public Product(string productName, int wholePrice, int fractionalPrice) 
        : base(wholePrice, fractionalPrice)
    {
        ProductName = productName;
    }

    public void PrintProductInfo()
    {
        Console.WriteLine($"Product: {ProductName}, Price: {Price}");
    }
    
    public void SetProductName(string newName)
    {
        ProductName = newName;
    }
}