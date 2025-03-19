namespace Task_1_Drama;

class Program
{
    static void Main(string[] args)
    {
        Play play = new Play("Romeo and Juliet", "William Shakespeare", "Tragedy", 1597);
        
        play.DisplayInfo();

        play.ChangeTitle("Hamlet");

        play.ChangeYear(1603);

        Console.WriteLine("\nUpdated play information:");
        play.DisplayInfo();
        play = null;
        
        
        GC.Collect();
        GC.WaitForPendingFinalizers(); 
        
        Thread.Sleep(1000); 

        Console.WriteLine("Program completed.");
    }
}