namespace HW_MusicalInstrument.Instruments;

public class Cello() 
    : MusicalInstrument("Cello", "Stringed bowed instrument", "Developed from viola da gamba in the XVI century") 
{
    public override void Sound()
    {
        Console.WriteLine("The cello produces a deep, expressive sound");
    }
}