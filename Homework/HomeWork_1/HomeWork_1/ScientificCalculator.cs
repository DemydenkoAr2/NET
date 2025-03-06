namespace HomeWork_1;

public class ScientificCalculator : BasicCalculator
{   
    public ScientificCalculator(History history) : base(history) { }

    private double PerformMathOperation(string operationName, Func<double, double> operation, double x)
    {
        double result = operation(x);
        LogOperation($"{operationName}({x}) = {result}");
        return result;
    }

    public double Sine(double x) => PerformMathOperation("Sin", Math.Sin, x);
    public double Cosine(double x) => PerformMathOperation("Cos", Math.Cos, x);
    public double Tangent(double x) => PerformMathOperation("Tan", Math.Tan, x);
    public double Logarithm(double x) => PerformMathOperation("Log", Math.Log, x);
    public double Square(double x) => PerformMathOperation("Square", v => v * v, x);
    public double Cube(double x) => PerformMathOperation("Cube", v => v * v * v, x);
}