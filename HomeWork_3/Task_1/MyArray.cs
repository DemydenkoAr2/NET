namespace Task_1;

public class MyArray : IOutput
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
}