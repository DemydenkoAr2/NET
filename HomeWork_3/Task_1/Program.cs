namespace Task_1;

class Program
{
    static void Main(string[] args)
    {
        int[] arr = {1, 2, 3, 4, 5};

        MyArray myArray = new MyArray(arr);
        
        myArray.Show();
        myArray.Show("Some additional information");
    }
}