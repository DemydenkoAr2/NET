namespace HW_MusicalInstrument;

public abstract class MusicalInstrument
{
    private string Name { get; set; }
    private string Description { get; set; }
    private string HistoryInfo { get; set; }

    protected MusicalInstrument(string name, string description, string historyInfo)
    {
        Name = name;
        Description = description;
        HistoryInfo = historyInfo;
    }
    
    public abstract void Sound();
    
    public void Show()
    {
        Console.WriteLine($"Name of instrument: {Name}");
    }

    public void Desc()
    {
        Console.WriteLine($"Description: {Description}");
    }

    public void History()
    {
        Console.WriteLine($"About: {HistoryInfo}");
    }
}