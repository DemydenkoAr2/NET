namespace Task_1;

public class MyArray : IOutput, IMath
{
    private int[] _array;

    public MyArray(int[] array)
    {
        _array = array;
    }

    public void Show()
    {
        Console.WriteLine("Array's elements: ");
        foreach (var item in _array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    public void Show(string info)
    {
        Console.WriteLine(info);
        Console.WriteLine("Array's elements: ");

        foreach (var item in _array)
        {
            Console.Write(item + " ");
        }

        Console.WriteLine();
    }

    public int Max()
    {
        return _array.Length == 0 ? 0 : _array.Max();
    }

    public int Min()
    {
        return _array.Length == 0 ? 0 : _array.Min();
    }

    public float Average()
    {
        if (_array.Length == 0)
        {
            Console.WriteLine("Array is empty");
            return 0;
        }

        float sumAvg = 0.0f;
        
        foreach (var element in _array)
        {
            sumAvg += element;
        }
        
        return sumAvg / _array.Length;
    }

    public bool Search(int valueToSearch)
    {
        if (_array.Length == 0) return false;
        
        foreach (int value in _array)
        {
            if (value == valueToSearch) return true;
        }
        
        return false;
    }
}