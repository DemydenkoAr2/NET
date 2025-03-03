namespace HW_Money;

class Program
{
    static void Main(string[] args)
    {
        Product iPhone = new Product("IPhone 16", 999, 49);
        Product macBook = new Product("MacBook Air M1", 1999, 49);
        
        iPhone.PrintPrice();
        macBook.PrintPrice();
        
        iPhone.Decrease(10, 99);
        iPhone.PrintProductInfo();
        
        macBook.Increase(120, 70);
        macBook.PrintProductInfo();
    }
}