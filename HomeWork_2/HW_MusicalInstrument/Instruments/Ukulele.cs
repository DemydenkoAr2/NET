namespace HW_MusicalInstrument.Instruments;

public class Ukulele() : MusicalInstrument("Ukulele", "Four-string Hawaiian guitar", "Established in the 1880s in Hawaii")
{
    public override void Sound()
    {
        Console.WriteLine("The ukulele produces a soft, pleasant sound");
    }
}