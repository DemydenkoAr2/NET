namespace HW_Money;

public class Money
{
    public string Price => FormatPrice();
    private int WholePrice { get; set; }
    private int FractionalPrice { get; set; }

    public Money(int wholePrice, int fractionalPrice)
    {
        WholePrice = Math.Max(wholePrice, 0);
        FractionalPrice = Math.Min(Math.Max(fractionalPrice, 0), 99);
    }

    private string FormatPrice()
    {
        return $"{WholePrice}.{FractionalPrice}";
    }

    public void PrintPrice()
    {
        Console.WriteLine(Price);
    }

    public void Increase(int wholePrice, int fractionalPrice)
    {
        WholePrice += Math.Max(wholePrice, 0);
        FractionalPrice += Math.Min(Math.Max(fractionalPrice, 0), 99);

        if (FractionalPrice >= 100)
        {
            FractionalPrice -= 100;
            WholePrice++;
        }
    }

    public void Decrease(int wholePrice, int fractionalPrice)
    {
        WholePrice -= Math.Max(wholePrice, 0);
        FractionalPrice -= Math.Min(Math.Max(fractionalPrice, 0), 99);

        if (FractionalPrice < 0)
        {
            FractionalPrice += 100;
            WholePrice--;
        }
    }
}