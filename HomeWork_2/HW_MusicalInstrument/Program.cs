using HW_MusicalInstrument.Instruments;

namespace HW_MusicalInstrument;

class Program
{
    static void Main(string[] args)
    {
        List<MusicalInstrument> instruments = [new Cello(), new Trombone(), new Ukulele(), new Violin()];
        
        foreach (var instrument in instruments)
        {
            instrument.Show();
            instrument.Sound();
            instrument.Desc();
            instrument.History();
            Console.WriteLine();
        }
    }
}