namespace Task_1;

class Program
{
    static void Main(string[] args)
    {
        int[] arr = [15, 30, 20, 46, 50];
        
        int[] expectedResultAsc = [15, 20, 30, 46, 50];
        int[] expectedResultDesc = [50, 46, 30, 20, 15];
        
        MyArray myArray = new MyArray(arr);
        
        Console.WriteLine("Max: " + myArray.Max()); //  50
        Console.WriteLine("Min: " + myArray.Min()); //  10
        Console.WriteLine("Avg: " + myArray.Average()); // 30.0

        Console.WriteLine("Search for 30: " + myArray.Search(30)); // True
        Console.WriteLine("Search for 100: " + myArray.Search(100)); // False
        
        myArray.Show("Isn't sorted | ");
        Console.WriteLine(myArray.UnitTest(expectedResultAsc, 15)); // Test Failed, We didn't sort the array
        
        myArray.SortAsc();
        myArray.Show("Sorted by param Asc | ");
        Console.WriteLine(myArray.UnitTest(expectedResultAsc, 15)); // Passed
        
        myArray.SortDesc();
        myArray.Show("Sorted by Desc | ");
        Console.WriteLine(myArray.UnitTest(expectedResultDesc, 50)); // Passed
        
        myArray.SortByParam(true);
        myArray.Show("Sorted by param Asc | ");
        Console.WriteLine(myArray.UnitTest(expectedResultAsc, 15)); // Passed
    }
}