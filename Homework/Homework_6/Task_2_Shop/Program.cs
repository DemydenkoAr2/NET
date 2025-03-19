namespace Task_2_Shop;

class Program
{
    static void Main(string[] args)
    {
        Shop lunardisShop = new("Lunardis", "3094 Withers ave", "Grocery", ["Main: +1-925-333-1111"]);
        lunardisShop.DisplayInfo();
        
        lunardisShop = null;

        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
}