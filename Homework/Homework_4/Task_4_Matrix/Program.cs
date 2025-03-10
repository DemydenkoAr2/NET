namespace Task_4_Matrix;

class Program
{
    static void Main()
    {
        Matrix m1 = new Matrix(new[,] { {1, 2}, {3, 4} });
        Matrix m2 = new Matrix(new[,] { {5, 6}, {7, 8} });
        
        Console.WriteLine("Matrix 1:");
        m1.Print();
        
        Console.WriteLine("\nMatrix 2:");
        m2.Print();
        
        Console.WriteLine("\nSum:");
        (m1 + m2).Print();
        
        Console.WriteLine("\nDifference:");
        (m1 - m2).Print();
        
        Console.WriteLine("\nProduct:");
        (m1 * m2).Print();
        
        Console.WriteLine("\nScalar multiplication:");
        (2 * m1).Print();
        
        Console.WriteLine($"\nEquality: {m1 == m2}");
        Console.WriteLine($"Inequality: {m1 != m2}");
    }
}