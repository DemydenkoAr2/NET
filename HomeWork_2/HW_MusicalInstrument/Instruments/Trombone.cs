namespace HW_MusicalInstrument.Instruments;

public class Trombone() 
    : MusicalInstrument("Trombone", "Copper wind instrument", "Comes from a fifteenth-century sakbut")
{
    public override void Sound()
    {
        Console.WriteLine("Trombone produces a deep, powerful sound");
    }
}