namespace HomeWork_1;

public class BasicCalculator : Calculator
{
    public BasicCalculator(History history) : base(history) { }
    
    public double Add(double a, double b)
    {
        double result = a + b;
        LogOperation($"{a} + {b} = {result}");
        return result;
    }

    public double Subtract(double a, double b)
    {
        double result = a - b;
        LogOperation($"{a} - {b} = {result}");
        return result;
    }

    public double Multiply(double a, double b)
    {
        double result = a * b;
        LogOperation($"{a} * {b} = {result}");
        return result;
    }

    public double Divide(double a, double b)
    {
        if (b == 0)
        {
            LogDivisionByZero();
            return 0;
        }

        double result = a / b;
        LogOperation($"{a} / {b} = {result}");
        return result;
    }

    public double Modulo(double a, double b)
    {
        if (b == 0)
        {
            LogDivisionByZero();
            return 0;
        }
        
        double result = a % b;
        LogOperation($"{a} % {b} = {result}");
        return result;
    }

    public double Percentage(double a, double percentage)
    {
        double result = (a * percentage) / 100.0;
        LogOperation($"{a} % {percentage} = {result}");
        return result;
    }
}