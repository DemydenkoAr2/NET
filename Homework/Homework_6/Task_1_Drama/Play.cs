namespace Task_1_Drama;

public class Play : IDisposable
{
    private string Title { get; set; }
    private string Author { get; set; }
    private string Genre { get; set; }
    private int Year { get; set; }

    public Play(string title, string author, string genre, int year)
    {
        Title = title;
        Author = author;
        Genre = genre;
        Year = year;
        Console.WriteLine($"Play \"{Title}\" created.");
    }

    // Destructor
    ~Play()
    {
        Console.WriteLine($"Play \"{Title}\" destroyed. Author: {Author}, genre: {Genre}, year: {Year}");
    }

    public void Dispose()
    {
        Console.WriteLine($"П'єса \"{Title}\" видалена через Dispose.");
        GC.SuppressFinalize(this); // Відміна виклику деструктора
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Genre: {Genre}");
        Console.WriteLine($"Year: {Year}");
    }

    public void ChangeTitle(string newTitle)
    {
        Console.WriteLine($"Title changed from \"{Title}\" to \"{newTitle}\".");
        Title = newTitle;
    }

    public void ChangeYear(int newYear)
    {
        Console.WriteLine($"Year changed from {Year} to {newYear}.");
        Year = newYear;
    }
}