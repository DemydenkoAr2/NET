namespace HW_MusicalInstrument.Instruments;

public class Violin()
    : MusicalInstrument("Violin", "Stringed bowed instrument", "Originated in Italy in the XVI century")
{
    public override void Sound()
    {
        Console.WriteLine("The violin produces a melodic, high-pitched sound");
    }
}