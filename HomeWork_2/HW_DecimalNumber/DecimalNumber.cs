using System.Text;

namespace HW_DecimalNumber;

public class DecimalNumber
{
    private readonly decimal _number;

    private int _integerPart;
    private int _fractionalPart;
    
    public DecimalNumber(decimal number)
    {
        _number = number;
        SplitParts();
    }

    public void SplitParts()
    {
        _integerPart = (int)Math.Truncate(_number);
        
        decimal fractionalPartDecimal = _number - _integerPart;
        fractionalPartDecimal = Math.Round(fractionalPartDecimal * 100);
        
        _fractionalPart = System.Convert.ToInt32(fractionalPartDecimal);
    }
    
    public string Convert(int numeralSystem)
    {
        string result = "";
        
        string systemName = numeralSystem switch
        {
            2 => "Binary: ",
            8 => "Octal: ",
            16 => "Hexadecimal: ",
            _ => "Invalid numeral system"
        };

        if (numeralSystem == 2)
        {
            result = systemName + ConvertToBinary(_integerPart) + "." + ConvertToBinary(_fractionalPart);
        }
        else if (numeralSystem is 8 or 16)
        {
            result += systemName + System.Convert.ToString(_integerPart, numeralSystem) +
                      "." +
                      System.Convert.ToString(_fractionalPart, numeralSystem);
        }
        else
        {
            Console.WriteLine(systemName);
        }
        return result;
    }

    private string ConvertToBinary(int value)
    {
        if (value == 0) return "0";
        
        StringBuilder binary = new StringBuilder();

        while (value > 0)
        {
            int remainder = value % 2;
            binary.Insert(0, remainder);
            value /= 2;
        }
        return binary.ToString();
    }
}



