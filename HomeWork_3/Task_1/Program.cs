namespace Task_1;

class Program
{
    static void Main(string[] args)
    {
        int[] arr = [15, 30, 20, 46, 50];

        MyArray myArray = new MyArray(arr);
        
        myArray.Show();
        myArray.Show("Some additional information");
        
        Console.WriteLine("Max: " + myArray.Max()); //  50
        Console.WriteLine("Min: " + myArray.Min()); //  10
        Console.WriteLine("Avg: " + myArray.Average()); // 30.0

        Console.WriteLine("Search for 30: " + myArray.Search(30)); // True
        Console.WriteLine("Search for 100: " + myArray.Search(100)); // False
        
        
        myArray.SortAsc();
        myArray.Show("Sorted by Asc");
        
        myArray.SortDesc();
        myArray.Show("Sorted by Desc");
        
        myArray.SortByParam(true);
        myArray.Show("Sorted by param - Asc");
        
        
    }
}