namespace HomeWork_1;

class Program
{
    static void Main(string[] args)
    {
        History history = new History();
        BasicCalculator basicCalculator = new BasicCalculator(history);
        ScientificCalculator scientificCalculator = new ScientificCalculator(history);
        
        history.Display();
        
        basicCalculator.Add(22, 22);
        basicCalculator.Subtract(22, 11);
        basicCalculator.Divide(10, 0);
        history.Undo();
        basicCalculator.Multiply(2, 11);
        basicCalculator.Modulo(10, 3);
        
        Console.WriteLine("_______");
        
        scientificCalculator.Add(10, 10);
        scientificCalculator.Sine(2);
        scientificCalculator.Square(2);
        scientificCalculator.Cube(4);

        history.Display();
    }
}