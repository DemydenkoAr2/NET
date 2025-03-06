using System.Linq;
namespace Task_1;

public class MyArray : IOutput, IMath, ISort
{
    private int[] _array;

    public MyArray(int[] array)
    {
        _array = array;
    }

    public void Show()
    {
        Console.Write("Array's elements: ");
        foreach (var item in _array)
        {
            Console.Write(item + " ");
        }

        Console.WriteLine();
    }

    public void Show(string info)
    {
        Console.Write(info);
        Console.Write("Array's elements: ");

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

    public void SortAsc()
    {
        _array = _array.OrderBy(x => x).ToArray();
    }

    public void SortDesc()
    {
        _array = _array.OrderByDescending(x => x).ToArray();
    }

    public void SortByParam(bool isAsc)
    {
        if (isAsc)
        {
            _array = _array.OrderBy(x => x).ToArray();
        }
        else
        {
            _array = _array.OrderByDescending(x => x).ToArray();
        }
    }

    public string UnitTest(int[] expectedResult, int firstElement)
    {
        if (expectedResult.SequenceEqual(_array) && firstElement == _array[0])
        {
            return "Test Passed";
        }
        
        return "Test Failed";
    }
}