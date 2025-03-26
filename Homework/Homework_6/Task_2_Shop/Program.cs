namespace Task_2_Shop;

class Program
{
    static void Main(string[] args)
    {
        // Shop lunardisShop = new("Lunardis", "3094 Withers ave", "Grocery", ["Main: +1-925-333-1111"]);
        // lunardisShop.DisplayInfo();

        using (Shop target = new("Target", "548 N Civic dr", "Tech", ["Main: +1-925-332-1221"]))
        {
            target.DisplayInfo();
            target.UpdateInfo("458 N Civic blv", "Tech");
            target.DisplayInfo();
        }

    }
}