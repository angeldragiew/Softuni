using System;
using System.Numerics;

namespace _11Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int snowBallsNum = int.Parse(Console.ReadLine());
            BigInteger snowBallValue = 0;

            int snowballSnowSafe = 0;
            int snowballTimeSafe = 0;
            int snowballQualitySafe = 0;
            BigInteger snowBallValueSafe = 0;

            for (int i = 1; i <= snowBallsNum; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                snowBallValue = BigInteger.Pow(snowballSnow / snowballTime, snowballQuality);

                if (snowBallValue >= snowBallValueSafe)
                {
                    snowBallValueSafe = snowBallValue;
                    snowballSnowSafe = snowballSnow;
                    snowballTimeSafe = snowballTime;
                    snowballQualitySafe = snowballQuality;
                }
            }

            Console.WriteLine($"{snowballSnowSafe} : {snowballTimeSafe} = {snowBallValueSafe} ({snowballQualitySafe})");


        }
    }
}
