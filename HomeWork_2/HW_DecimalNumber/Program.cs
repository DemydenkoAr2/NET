namespace HW_DecimalNumber;

class Program
{
    static void Main(string[] args)
    {
        DecimalNumber n = new DecimalNumber(42.55m);
        
        n.SplitParts();
        n.Print();
    }
}