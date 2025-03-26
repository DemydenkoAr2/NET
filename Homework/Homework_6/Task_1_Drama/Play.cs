namespace Task_1_Drama;

public class Play : IDisposable
{
    private bool _disposed = false;
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
    }

    // Destructor
    ~Play()
    {
        Console.WriteLine($"Play \"{Title}\" destroyed. Author: {Author}, genre: {Genre}, year: {Year}");
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                Console.WriteLine($"Play \"{Title}\" destroyed. Author: {Author}, genre: {Genre}, year: {Year}");
            }
            
            _disposed = true;
        }
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}, Author: {Author}, Genre: {Genre}, Year: {Year}");
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