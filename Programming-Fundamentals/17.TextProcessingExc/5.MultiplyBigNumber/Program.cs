using System;
using System.Linq;
using System.Text;

namespace _5.MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var sb = new StringBuilder();
            
            string num = Console.ReadLine().TrimStart('0');
            int multiplier = int.Parse(Console.ReadLine());

            int delimiter = 0;
            if (multiplier == 0)
            {
                Console.WriteLine("0");
                return;
            }
            
            foreach (var item in num.Reverse())
            {
                int currNum = int.Parse(item.ToString());

                currNum =(currNum* multiplier) + delimiter;

                int remainder = currNum % 10;
                delimiter = currNum / 10;

                sb.Insert(0, remainder);
            }

            if (delimiter > 0)
            {
                sb.Insert(0, delimiter);
            }
            
            Console.WriteLine(sb);
        }
    }
}
