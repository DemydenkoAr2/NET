namespace HW_DecimalNumber;

class Program
{
    static void Main(string[] args)
    {
        DecimalNumber number = new DecimalNumber(42.10m);
        number.SplitParts();

       Console.WriteLine(number.Convert(2));
       Console.WriteLine(number.Convert(8));
       Console.WriteLine(number.Convert(16));
       
       Console.WriteLine(number.Convert(3)); // Wrong numeral system
    }
}