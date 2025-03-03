namespace HW_DecimalNumber;

public class DecimalNumber
{
    private readonly decimal number;

    private int integerPart;
    private decimal fractionalPart;

    public DecimalNumber(decimal number)
    {
        this.number = number;
    }

    public void SplitParts()
    {
        integerPart = (int)Math.Truncate(number);
        
        fractionalPart = number - integerPart;
        // fractionalPart = Math.Round(fractionalPart * 100);

    }

    public void Print()
    {
        Console.WriteLine(integerPart);
        Console.WriteLine(fractionalPart);
    }

    public void ToBinary()
    {
        string result = integerPart.ToString();
        result = ToBinary();

    }
}