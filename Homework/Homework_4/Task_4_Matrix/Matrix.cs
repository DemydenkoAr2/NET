namespace Task_4_Matrix;
using System;

public class Matrix
{
    private int[,] data;

    private int Rows => data.GetLength(0);
    private int Columns => data.GetLength(1);
    
    public int this[int i, int j]
    {
        get => data[i, j];
        set => data[i, j] = value;
    }
    
    public Matrix(int rows, int cols)
    {
        data = new int[rows, cols];
    }
    
    public Matrix(int[,] array)
    {
        data = (int[,])array.Clone();
    }
    
    public static Matrix operator +(Matrix a, Matrix b)
    {
        if (a.Rows != b.Rows || a.Columns != b.Columns)
            throw new ArgumentException("Matrices must have same dimensions");
            
        Matrix result = new Matrix(a.Rows, a.Columns);
        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < a.Columns; j++)
                result[i, j] = a[i, j] + b[i, j];
        return result;
    }
    
    public static Matrix operator -(Matrix a, Matrix b)
    {
        if (a.Rows != b.Rows || a.Columns != b.Columns)
            throw new ArgumentException("Matrices must have same dimensions");
            
        Matrix result = new Matrix(a.Rows, a.Columns);
        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < a.Columns; j++)
                result[i, j] = a[i, j] - b[i, j];
        return result;
    }
    
    public static Matrix operator *(Matrix a, Matrix b)
    {
        if (a.Columns != b.Rows)
            throw new ArgumentException("Invalid matrix dimensions");
            
        Matrix result = new Matrix(a.Rows, b.Columns);
        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < b.Columns; j++)
                for (int k = 0; k < a.Columns; k++)
                    result[i, j] += a[i, k] * b[k, j];
        return result;
    }
    
    public static Matrix operator *(int scalar, Matrix m)
    {
        Matrix result = new Matrix(m.Rows, m.Columns);
        for (int i = 0; i < m.Rows; i++)
            for (int j = 0; j < m.Columns; j++)
                result[i, j] = scalar * m[i, j];
        return result;
    }
    
    public static Matrix operator *(Matrix m, int scalar) => scalar * m;
    
    public static bool operator ==(Matrix a, Matrix b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (a is null || b is null) return false;
        
        if (a.Rows != b.Rows || a.Columns != b.Columns) return false;
        
        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < a.Columns; j++)
                if (a[i, j] != b[i, j]) return false;
        return true;
    }
    
    public static bool operator !=(Matrix a, Matrix b) => !(a == b);
    
    public void Print()
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
                Console.Write($"{data[i, j],4}");
            Console.WriteLine();
        }
    }
}
