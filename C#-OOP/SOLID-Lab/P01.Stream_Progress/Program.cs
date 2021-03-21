using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            File file = new File("ss", 20, 1);
            Music music = new Music("Angel", "asdas", 10, 1);
            StreamProgressInfo stream = new StreamProgressInfo(music);
            Console.WriteLine(stream.CalculateCurrentPercent());
        }
    }
}
